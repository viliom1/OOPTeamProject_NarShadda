using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkGame.Item
{
    struct RingOfPower : IItem
    {
        private int increment;
        private string name;
        private Bitmap appearence;

        public RingOfPower(int increment, string name, Bitmap appearence) : this()
        {
            this.increment = increment;
            this.name = name;
            this.appearence = appearence;
        }

        public int Increment { get; set; }
        public string Name { get; set; }
        public Bitmap Appearence { get; set; }
    }
}
