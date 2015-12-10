using System;
using System.Threading;
using System.Drawing;


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
                isMovement = true;
                if (Game.Character.Position[0] == lastPos)
                {
                    isMovement = false;
                    steps = 0;
                }
                
                if (!isMovement)
                {
                    gFrame.DrawImage
                        (Game.Character.Animation[0],Game.Character.Position[0],Game.Character.Position[1]);
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
                lastPos = Game.Character.Position[0];
               
                drawHandle.DrawImage(frame, 0, 0);

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
