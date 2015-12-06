using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
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
            int framesRendered = 0;
            long startTime = Environment.TickCount;
            long aniStartTime = Environment.TickCount;
            Raynor Raynor = new Raynor(new int[2] { 200, 200 });

            Bitmap frame = new Bitmap(Game.GameWidth, Game.GameHeight);
            Graphics gFrame = Graphics.FromImage(frame);

            Bitmap[] ani = new Bitmap[2];
                ani[0] = TeamworkGame.Resource1._1;
                ani[1] = TeamworkGame.Resource1._2;
                bool isFirst = true;
            while(true)
            {
                gFrame.FillRectangle(new SolidBrush(Color.Aqua),0,0,Game.GameWidth,Game.GameHeight);
                if (isRight)
                {
                    if (isFirst)
                    {
                        gFrame.DrawImage(Raynor.Animation[0], Raynor.Position[0], Raynor.Position[1]);

                        if (Raynor.Position[0] + 5 < 1000)
                        {
                            Raynor.MoveRight();
                        }

                        if (Environment.TickCount >= aniStartTime + 200)
                        {
                            isFirst = false;
                            aniStartTime = Environment.TickCount;

                        }

                    }
                    else
                    {
                        gFrame.DrawImage(Raynor.Animation[1], Raynor.Position[0], Raynor.Position[1]);
                        if (Raynor.Position[0] < 1000)
                        {
                            Raynor.MoveRight();
                        }
                        if (Environment.TickCount >= aniStartTime + 200)
                        {
                            isFirst = true;
                            aniStartTime = Environment.TickCount;

                        }
                    }
                    if (Raynor.Position[0] == 1000)
                    {
                        isRight = false;
                    }
                }

                else
                {
                    if (isFirst)
                    {
                        gFrame.DrawImage(Raynor.Animation[0], Raynor.Position[0], Raynor.Position[1]);

                        if (Raynor.Position[0] - 5 >= 0)
                        {
                            Raynor.MoveLeft();
                        }

                        if (Environment.TickCount >= aniStartTime + 200)
                        {
                            isFirst = false;
                            aniStartTime = Environment.TickCount;

                        }
                        

                    }
                    else
                    {
                        gFrame.DrawImage(Raynor.Animation[1], Raynor.Position[0], Raynor.Position[1]);
                        if (Raynor.Position[0]  - 5>= 0)
                        {
                            Raynor.MoveLeft() ;
                        }
                        if (Environment.TickCount >= aniStartTime + 200)
                        {
                            isFirst = true;
                            aniStartTime = Environment.TickCount;

                        }
                    }
                    if (Raynor.Position[0] == 0)
                    {
                        isRight = true;
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
                }

            }
        }
        public void Stop()
        {
            this.renderthread.Abort();
        }



    }
}
