using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TeamworkGame.Characters
{
    class Bullet
    {
        private int[] position;
        private int dmg;
        public int Speed { get; set; }
        public Bitmap Image { get; set; }

        public Bullet(int[] position,int dmg)
        {
            this.Position = position;
            this.dmg = dmg;
            this.Speed = 100;
            this.Image = Resource1.bullet;
        }

        public int[] Position { get; set; }
        public int Dmg { get; set; }
    }
}
