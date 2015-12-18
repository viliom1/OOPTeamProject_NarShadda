using System;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using System.Linq;
using TeamworkGame.Characters;


namespace TeamworkGame
{
    class GEngine
    {
        //Members
        private Graphics drawHandle;
        private Thread renderthread;

        //Constructor
        public GEngine(Graphics g)
        {
            this.drawHandle = g;
        }

        //Methods
        public void Initialize()
        {
            this.renderthread = new Thread(new ThreadStart(Render));
            this.renderthread.Start();
        }
        private void Render()
        {
            
            
            int framesRendered = 0;
            long moveStart = Environment.TickCount;
            long startTime = Environment.TickCount;
            long aniStartTime = Environment.TickCount;
            int lastPos = Game.Character.Position[0];
            
            Game.LoadScene(Game.SceneNumber);
            

            Bitmap frame = new Bitmap(Game.GameWidth, Game.GameHeight);
            Graphics gFrame = Graphics.FromImage(frame);
            
            
           
            while(true)
            {
                
                
                gFrame.DrawImage(Game.CurrentScene.Background, 0, 0, Game.GameWidth, Game.GameHeight);
                
                if (Game.CurrentScene.DeadEnemies.Any())
                {
                    foreach (var item in Game.CurrentScene.DeadEnemies)
                    {
                        gFrame.DrawImage(item.GetAnimation(), item.Position[0], item.Position[1]);
                    }
                }
                if (Game.CurrentScene.Enemies.Any())
                {
                    foreach (var item in Game.CurrentScene.Enemies)
                    {
                        gFrame.DrawImage(item.GetAnimation(), item.Position[0], item.Position[1]);
                    }
                    Game.EnemyAI();
                }
                

                
                foreach (var item in Game.EnemyBullets)
                {
                    gFrame.DrawImage(item.Image, item.Position[0], item.Position[1]);
                }
                
                
                if (Game.CurrentScene.QuestGiver != null)
                {
                    gFrame.DrawImage(Game.CurrentScene.QuestGiver.Animation[0], 
                        Game.CurrentScene.QuestGiver.Position[0], Game.CurrentScene.QuestGiver.Position[1]);
                    
                    if (Game.CurrentScene.QuestGiver.Interaction)
                    {
                        gFrame.DrawString(Game.CurrentScene.QuestGiver.Quest, new Font(FontFamily.GenericSansSerif, 25, FontStyle.Italic),
                           new SolidBrush(Color.Gold), Game.CurrentScene.QuestGiver.Position[0],
                           Game.CurrentScene.QuestGiver.Position[1] - 50);
                    }
                }

                if (Game.CurrentScene.Vendor != null)
                {
                    gFrame.DrawImage(Game.CurrentScene.Vendor.Animation[0]
                        ,Game.CurrentScene.Vendor.Position[0],Game.CurrentScene.Vendor.Position[1]);
                    if (Game.CurrentScene.Vendor.Interaction)
                    {
                        gFrame.DrawString("ACTUAL INTERACTION PENDING", new Font(FontFamily.GenericSansSerif, 25, FontStyle.Italic),
                           new SolidBrush(Color.Gold), Game.CurrentScene.Vendor.Position[0]
                           , Game.CurrentScene.Vendor.Position[1]);
                    }
                }
                Game.InteractionUpdate();
                gFrame.DrawImage
                    (Game.Character.GetAnimation(), Game.Character.Position[0], Game.Character.Position[1]);
                
                
                if (Game.Bullets.Any() || Game.EnemyBullets.Any())
                {
                    Game.BullteUpdate();
                    foreach (var item in Game.Bullets)
                    {
                        gFrame.DrawImage(item.Image,item.Position[0],item.Position[1]);
                    }
                }
                

                gFrame.DrawImage(Game.GetHealthBar(), 10, 10);
                gFrame.DrawImage(Resource1.Gold1, 176, 1);
                gFrame.DrawString(Game.Character.Gold.ToString(), new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold),
                    new SolidBrush(Color.Gold), 220f, 5f);
                if (Game.SeeInventory)
	            {
                    gFrame.DrawImage(Resource1.Inventory, 890, 10);
	            }
                Game.SceneUpdate();
                drawHandle.DrawImage(frame, 0, 0);
                if (Game.Character.IsDead)
                {
                    gFrame.DrawImage(Resource1.game_over,Game.GameWidth/2-150,Game.GameHeight/2);
                    break;
                }
                
                Game.EnemyIsDead();
                
                //Debug
                framesRendered++;
                if (Environment.TickCount >= startTime + 1000)
                {
                    Console.WriteLine("GEngine: {0}fps",framesRendered);
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                    Console.WriteLine("Game: Character health: " + Game.Character.Health);
                    foreach (var item in Game.Enemies)
                    {
                        Console.WriteLine("Game: " + item);
                    }
                }

            }
            while (true)
            {
                drawHandle.DrawImage(frame,0,0);
            }
        }
        public void Stop()
        {
            this.renderthread.Abort();
        }

    }
}
