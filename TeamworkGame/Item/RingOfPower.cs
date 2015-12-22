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
        private int price;
        

        public RingOfPower(int increment, string name, Bitmap appearence, int price) : this()
        {
            this.increment = increment;
            this.name = name;
            this.appearence = appearence;
            this.price = price;
        }

        public int Increment { get; set; }
        public string Name { get; set; }
        public Bitmap Appearence { get; set; }
        public int Price { get; set; }


        public bool IsConsumable
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
