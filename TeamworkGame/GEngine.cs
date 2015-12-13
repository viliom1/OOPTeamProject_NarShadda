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
            int steps = 0;
            

            Bitmap frame = new Bitmap(Game.GameWidth, Game.GameHeight);
            Graphics gFrame = Graphics.FromImage(frame);
            
            
           
            while(true)
            {
                
                gFrame.DrawImage(Resource1.Background, 0, 0, Game.GameWidth, Game.GameHeight);
                foreach (var item in Game.Enemies)
                {
                    gFrame.DrawImage(item.GetAnimation(), item.Position[0], item.Position[1]);
                }

                Game.EnemyAI();
                foreach (var item in Game.EnemyBullets)
                {
                    gFrame.DrawImage(item.Image, item.Position[0], item.Position[1]);
                }
                
                gFrame.DrawImage
                    (Game.Character.GetAnimation(),Game.Character.Position[0],Game.Character.Position[1]);
                
                
                if (Game.Bullets.Any() || Game.EnemyBullets.Any())
                {
                    Game.BullteUpdate();
                    foreach (var item in Game.Bullets)
                    {
                        gFrame.DrawImage(item.Image,item.Position[0],item.Position[1]);
                    }
                }
               
                drawHandle.DrawImage(frame, 0, 0);

               
                
                //Debug
                framesRendered++;
                if (Environment.TickCount >= startTime + 1000)
                {
                    Console.WriteLine("GEngine: {0}fps",framesRendered);
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                    foreach (var item in Game.Enemies)
                    {
                        Console.WriteLine(item);
                    }
                    
                }

            }
        }
        public void Stop()
        {
            this.renderthread.Abort();
        }

    }
}
