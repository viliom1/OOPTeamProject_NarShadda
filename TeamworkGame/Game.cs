using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TeamworkGame
{
    class Game
    {
        //constants 
        public const int GameHeight = 700;
        public const int GameWidth = 1200;
        //members
        private GEngine gEngine;
        internal void StartGraphics(Graphics g)
        {
            this.gEngine = new GEngine(g);
            this.gEngine.Initialize();
        }
        
        public void GameStop()
        {
            gEngine.Stop();
        }

    }
}
