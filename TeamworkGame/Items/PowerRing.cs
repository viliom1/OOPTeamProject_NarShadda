using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TeamworkGame.Items
{
     struct PowerRing
    {
        //Fields

        private string name;
        private int increment;
        private Bitmap appearence;

        //Constructor
         public PowerRing(string name, int increment, Bitmap appearence) : this()
         {
             Name = "Power Ring";
             Increment = 15;
             Appearence = Resource1.RingOfPower;

         }

         

         //Properties
         public string Name
         {
             get { return this.name; }
             protected set { this.name = value; }
         }
        public int Increment
        { 
            get { return this.increment; } 
            protected set { this.increment = value; }
        }
        public Bitmap Appearence 
        { 
            get {return  this.appearence;}
            protected set { this.appearence = value; } 
        }



    }
}
