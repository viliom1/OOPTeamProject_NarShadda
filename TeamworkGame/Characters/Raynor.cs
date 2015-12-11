using System;
using System.Drawing;


namespace TeamworkGame.Characters
{
    class Raynor : PlayableChar, IRaynor
    {
        //Constructor
        public Raynor(int[] position)
            : base( position,500,5)
        {
            this.Animation = new Bitmap[2] { new Bitmap(Resource1._1), new Bitmap(Resource1._2) };
            this.MoveSpeed = 5;
        }
        //Methods
        public override void  Attack()
        {
            Game.Bullets.Add(new Bullet
                (new[] { Game.Character.Position[0] + 90, Game.Character.Position[1] + 115 }, 20));
        }

        public void PenetratingRound()
        {
            throw new NotImplementedException();
        }
    }
}
