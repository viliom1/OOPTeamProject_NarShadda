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
        //members
        private static GEngine gEngine;
        public static  PlayableChar Character { get; private set; }
        public static List<Bullet> Bullets = new List<Bullet>();
        public static List<Enemy> Enemies { get; private set; }
        public static List<Bullet> EnemyBullets = new List<Bullet>();
        internal static void StartGraphics(Graphics g)
        {
            Enemies = new List<Enemy>();
            Character = new Raynor(new int[]{100,350});
            Enemies.Add(new Enemy(new int[] { 1000, 330 }));
            gEngine = new GEngine(g);
            gEngine.Initialize();
        }
        
        public static  void GameStop()
        {
            gEngine.Stop();
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
            foreach (var item in Enemies)
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

        public static void EnemyIsDead()
        {
            foreach (var item in Enemies)
            {
                if (item.Health <= 0)
                {
                    Enemies.Remove(item);
                }
            }
        }

        public static void BullteUpdate()
        {
            for (int i = 0; i < Bullets.Count; i++)
            {
                bool isHit = false;
                for (int j = 0; j < Enemies.Count; j++)
                {
                    if (Bullets[i].Position[0] + Bullets[i].Speed >= Enemies[j].Position[0])
                    {
                        Enemies[i].Collide(Bullets[i].Dmg);
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
                if (Bullets[i].Position[0]  - Character.Position[0] >= 500)
                {
                    Bullets.Remove(Bullets[i]);
                    i--;
                }
                else
                {
                    Bullets[i].Position[0] += Bullets[i].Speed;
                }
            }
            for (int i = 0; i < EnemyBullets.Count; i++)
            {
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
    }
}
