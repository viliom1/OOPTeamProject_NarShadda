﻿using System;
using System.Drawing;


namespace TeamworkGame.Characters
{
    class Raynor : PlayableChar, IRaynor
    {
        //Constructor
        public Raynor(int[] position)
            : base(position, 5, 100)
        {
            this.Animation = new Bitmap[2] { new Bitmap(Resource1._1), new Bitmap(Resource1._2) };
            this.MoveSpeed = 5;
            this.Gold = 10000;

        }
        //Methods
        public override void  Attack()
        {
            if (!IsDucking)
            {
                Game.Bullets.Add(new Bullet
               (new[] { Game.Character.Position[0] + 90, Game.Character.Position[1] + 115 }, 20, Resource1.bullet));
            }
           
        }

        public void PenetratingRound()
        {
            throw new NotImplementedException();
        }
    }
}
