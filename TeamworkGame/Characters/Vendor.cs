using System;
using TeamworkGame.Characters.Interface;
using System.Drawing;

namespace TeamworkGame.Characters
{
    class Vendor : Character, ITradable
    {

        //Fields
        // private Item[] inventory = new Item[15]; //the stash of the vendor

        //Constructor
        public Vendor(Bitmap[] animation, int[] position)
            : base( position, 0, 500, 0)
        {
        }
        // Methods
        public void Buy()
        {
            throw new NotImplementedException();
        }
        public void Sell()
        {
            throw new NotImplementedException();
        }

    }
}
