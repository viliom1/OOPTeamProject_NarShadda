using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TeamworkGame.Characters.Interface;

namespace TeamworkGame.Characters
{
    class Raynor : PlayableChar, IRaynor
    {
        //Constructor
        public Raynor(int[] position)
            : base( position, 400, 10)
        {
            this.Animation = new Bitmap[2] { new Bitmap(Resource1._1), new Bitmap(Resource1._2) };
        }
        //Methods
        public void Shoot()
        {
            throw new NotImplementedException();
        }

        public void PenetratingRound()
        {
            throw new NotImplementedException();
        }
    }
}
