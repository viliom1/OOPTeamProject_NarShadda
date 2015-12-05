using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TeamworkGame.Items
{
    abstract class Item
    {
        //Fields

        private string name;
        private int increment;
        private Bitmap appearence;

        //Constructor
        public Item(string name, int increment, Bitmap appearence)
        {
            this.Name = name;
            this.Increment = increment;
            this.Appearence = appearence;
        }
        //Properties
        public string Name { get; protected set; }
        public int Increment { get; protected set; }
        public Bitmap Appearence { get; protected set; }



    }
}
