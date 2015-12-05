using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            int framesRendered = 0;
            long startTime = Environment.TickCount;

            Bitmap frame = new Bitmap(Game.GameWidth, Game.GameHeight);
            Graphics gFrame = Graphics.FromImage(frame);


            while(true)
            {
                gFrame.FillRectangle(new SolidBrush(Color.Aqua),0,0,Game.GameWidth,Game.GameHeight);
                Bitmap stick = TeamworkGame.Resource1.black_stick_man_hi;
                gFrame.DrawImage(stick, 600, 200);

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
