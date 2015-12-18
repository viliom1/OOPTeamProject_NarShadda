using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using TeamworkGame.Characters;

namespace TeamworkGame
{
    static class Game
    {
        //constants 
        public const int GameHeight = 700;
        public const int GameWidth = 1200;
        public const int CharStartpositionX = 100;
        public const int CharStartPositionY = 350;
        //members
        private static int currentScene = 0;
        private static GEngine gEngine;
        public static bool SeeInventory { get; private set; }
        public static Bitmap Background { get; private set; }
        public static  PlayableChar Character { get; private set; }
        public static QuestGiver QuestGiver { get; private set; }
        public static Vendor Vendor { get; private set; }
        public static List<Bullet> Bullets = new List<Bullet>();
        public static List<Enemy> Enemies { get; private set; }
        public static List<Bullet> EnemyBullets = new List<Bullet>();
        public static Scene []  Scenes { get; private set; }
        public static Scene CurrentScene { get; private set; }
        public static int SceneNumber { get; private set; }

        internal static void StartGraphics(Graphics g)
        {
            Enemies = new List<Enemy>();
            Scenes = new Scene[5];
            Character = new Raynor(new int[]{CharStartpositionX,CharStartPositionY});
            Scenes[0] = Scene.LoadFirstScene();
            Scenes[1] = Scene.LoadSecondScene();
            Scenes[2] = Scene.LoadThirdScene();
            Scenes[3] = Scene.LoadFourthScene();
            Scenes[4] = Scene.LoadFifthScene();
            SceneNumber = 0;
            LoadScene(SceneNumber);
            gEngine = new GEngine(g);
            gEngine.Initialize();
        }

        
        
        public static  void GameStop()
        {
            gEngine.Stop();
        }

        public static void LoadScene(int sceneNumber)
        {
            Character.Position = new int[] {CharStartpositionX, CharStartPositionY};
            SceneNumber = sceneNumber;
            switch (sceneNumber)
            {
                case 0:
                    CurrentScene = Scenes[0];
                    break;
                case 1:
                    CurrentScene = Scenes[1];
                    break;
                case 2:
                    CurrentScene = Scenes[2];
                    break;
                case 3:
                    CurrentScene = Scenes[3];
                    break;
                case 4 :
                    CurrentScene = Scenes[4];
                    break;

            }
        }

        public static void  MoveRight()
        {
            Character.MoveRight();
        }

        public static void MoveLeft()
        {
            Character.MoveLeft();
        }
        public static void ChooseHero()
        {
            throw new NotImplementedException();
        }   
        public static void Attack()
        {
            Character.Attack();
        }

        public static void AddEnemy(int[] position)
        {
            Enemies.Add(new Enemy(position));

        }

        public static void EnemyAI()
        {
            foreach (var item in CurrentScene.Enemies)
            {
                if (!item.IsDead)
                {
                    if (item.Position[0] - Character.Position[0] <= 450)
                    {
                        item.Attack();
                    }
                    else if (item.Position[0] - Character.Position[0] >= 700)
                    {
                    }
                    else
                    {
                        item.MoveLeft();
                    } 
                }
                
            }
        }

        public static Bitmap GetHealthBar()
        {
            if (Character.Health > 90)
            {
                return Resource1.HealthBar100;
            }
            else if (Character.Health > 80 && Character.Health <= 90)
            {
                return Resource1.HealthBar90;
            }
            else if (Character.Health > 70 && Character.Health <= 80)
            {
                return Resource1.HealthBar80;
            }
            else if (Character.Health > 60 && Character.Health <= 70)
            {
                return Resource1.HealthBar70;
            }
            else if (Character.Health > 50 && Character.Health <= 60)
            {
                return Resource1.HealthBar60;
            }
            else if (Character.Health > 40 && Character.Health <= 50)
            {
                return Resource1.HealthBar50;
            }
            else if (Character.Health > 30 && Character.Health <= 40)
            {
                return Resource1.HealthBar40;
            }
            else if (Character.Health > 20 && Character.Health <= 30)
            {
                return Resource1.HealthBar30;
            }
            else if (Character.Health > 10 && Character.Health <= 20)
            {
                return Resource1.HealthBar20;
            }

            else if (Character.Health > 1 && Character.Health <= 10)
            {
                return Resource1.HealthBar10;
            }
            else
            {
                return Resource1.HealthBar0;
            }
        }
        
        public static void ShowInventory()
        {
            if (SeeInventory)
            {
                SeeInventory = false;
            }
            else
            {
                SeeInventory = true;
            }
        }
        public static void EnemyIsDead()
        {
            for (int i = 0; i < CurrentScene.Enemies.Count; i++)
            {
                if (CurrentScene.Enemies[i].Health <= 0)
                {
                    CurrentScene.DeadEnemies.Add(CurrentScene.Enemies[i]);
                    Character.CollectGold(CurrentScene.Enemies[i].DropGold());
                    CurrentScene.Enemies.Remove(CurrentScene.Enemies[i]);
                    i--;
                }
            }
            
        }

        public static void InteractionUpdate()
        {
            if (CurrentScene.QuestGiver != null)
            {
                if (CurrentScene.QuestGiver.Interaction)
                {
                    if (Character.Position[0] - CurrentScene.QuestGiver.Position[0] > 200
                        || CurrentScene.QuestGiver.Position[0] - Character.Position[0] > 200)
                    {
                        CurrentScene.QuestGiver.Interact();
                    }
                }
            }
            
        }
        public static void BullteUpdate()
        {
            for (int i = 0; i < Bullets.Count; i++)
            {
                bool isHit = false;
                for (int j = 0; j < CurrentScene.Enemies.Count; j++)
                {
                    if (Bullets[i].Position[0] + Bullets[i].Speed >= CurrentScene.Enemies[j].Position[0])
                    {
                        CurrentScene.Enemies[i].Collide(Bullets[i].Dmg);
                        Bullets.Remove(Bullets[i]);
                        i--;
                        isHit = true;
                        break;
                    }
                }
                if (isHit)
                {
                    continue;
                }
                if (Bullets[i].Position[0]  - Character.Position[0] >= Character.AttackRange)
                {
                    Bullets.Remove(Bullets[i]);
                    i--;
                }
                else
                {
                    Bullets[i].Position[0] += Bullets[i].Speed;
                }
            }

            if (SeeInventory)
            {
                
            }
            for (int i = 0; i < EnemyBullets.Count; i++)
            {
                bool isHit = false;
                if (!Character.IsDucking)
                {
                    if (EnemyBullets[i].Position[0] - EnemyBullets[i].Speed <= Character.Position[0])
                    {
                        Character.Collide(EnemyBullets[i].Dmg);
                        EnemyBullets.Remove(EnemyBullets[i]);
                        i--;
                        isHit = true;
                    }  
                }
                
                if (isHit)
                {
                    continue;
                }
                
                if (EnemyBullets[i].Position[0] - EnemyBullets[i].Speed <= 0)
                {
                    EnemyBullets.Remove(EnemyBullets[i]);
                    i--;
                }
                else
                {
                    EnemyBullets[i].Position[0] -= EnemyBullets[i].Speed;
                }
            }

            
        }



        internal static void SceneUpdate()
        {
            if (Character.Position[0] >= 1000)
            {
                currentScene ++;
                LoadScene(currentScene);
            }
        }
    }
}
