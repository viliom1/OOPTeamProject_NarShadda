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
        internal static void StartGraphics(Graphics g)
        {
            Character = new Raynor(new int[]{100,350});
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
            
        }
        
    }
}
