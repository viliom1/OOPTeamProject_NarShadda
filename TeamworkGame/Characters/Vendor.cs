using System;
using TeamworkGame.Characters.Interface;
using System.Drawing;
using TeamworkGame.Item;

namespace TeamworkGame.Characters
{
    public class Vendor : Character, ITradable
    {

        //Fields
        private IItem[] inventory = new IItem[15]; //the stash of the vendor

        //Constructor
        public Vendor(Bitmap[] animation, int[] position)
            : base( position, 0, 500, 0)
        {
            this.Animation = animation;
            this.Interaction = false;
        }
        public bool Interaction { get; private set; }

        // Methods
        public void Buy()
        {
            throw new NotImplementedException();
        }
        public void Sell()
        {
            throw new NotImplementedException();
        }


        internal void Interact()
        {
            if (!Interaction)
            {
                Interaction = true;
            }
            else
            {
                Interaction = false;
            }
        }
    }
}
