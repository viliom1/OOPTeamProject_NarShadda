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
            
            bool isRight = true;
            bool isMovement = false;
            int framesRendered = 0;
            long moveStart = Environment.TickCount;
            long startTime = Environment.TickCount;
            long aniStartTime = Environment.TickCount;
            int lastPos = Game.Character.Position[0];
            int steps = 0;
            

            Bitmap frame = new Bitmap(Game.GameWidth, Game.GameHeight);
            Graphics gFrame = Graphics.FromImage(frame);
            
            
            bool isFirst = true;
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
                
                
                if (!isMovement)
                {
                    gFrame.DrawImage
                        (Game.Character.Animation[0],
                        Game.Character.Position[0],
                        Game.Character.Position[1]);
                    if (Environment.TickCount >= aniStartTime + 220)
                    {
                        aniStartTime = Environment.TickCount;
                    }
                }
                else
                {
                    if (steps == 0)
                    {
                        isFirst = false;  
                    }
                    if (isFirst)
                    {
                        gFrame.DrawImage(Game.Character.Animation[0],
                            Game.Character.Position[0],Game.Character.Position[1]);
                        if (Environment.TickCount >= aniStartTime + 220)
                        {
                            isFirst = false;
                            aniStartTime = Environment.TickCount;
                            steps++;
                        }
                    }
                    else
                    {
                        gFrame.DrawImage(Game.Character.Animation[1],
                            Game.Character.Position[0], Game.Character.Position[1]);
                        if (Environment.TickCount >= aniStartTime + 220)
                        {
                            isFirst = true;
                            aniStartTime = Environment.TickCount;
                            steps++;
                        }
                    }
                    
                }
                
                
                if (Game.Bullets.Any() || Game.EnemyBullets.Any())
                {
                    Game.BullteUpdate();
                    foreach (var item in Game.Bullets)
                    {
                        gFrame.DrawImage(item.Image,item.Position[0],item.Position[1]);
                    }
                }
               
                drawHandle.DrawImage(frame, 0, 0);

                if (Environment.TickCount >= moveStart + 100)
                {
                    moveStart = Environment.TickCount;
                    if (lastPos == Game.Character.Position[0])
                    {
                        isMovement = false;
                    }
                    else
                    {
                        isMovement = true;
                    }
                    lastPos = Game.Character.Position[0];
                }
                //Debug
                framesRendered++;
                if (Environment.TickCount >= startTime + 1000)
                {
                    Console.WriteLine("GEngine: {0}fps",framesRendered);
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                    
                }

            }
        }
        public void Stop()
        {
            this.renderthread.Abort();
        }

    }
}
