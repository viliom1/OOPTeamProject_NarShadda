using System;
using TeamworkGame.Characters.Interface;
using System.Drawing;
using TeamworkGame.Item;

namespace TeamworkGame.Characters
{
    public class Vendor : Character, ITradable
    {

        //Fields
        private IItem[] inventory = new IItem[8]; //the stash of the vendor

        //RingOfPower powerRing = new RingOfPower(10, "MutrasRing", Resource1.RingOfPower, 100);
        

        //Constructor
        public Vendor(Bitmap[] animation, int[] position)
            : base( position, 0, 500, 0)
        {
            this.Animation = animation;
            this.Interaction = false;
            this.Inventory = new Item.Item[8];
            this.Inventory[0] = new Item.Item(20, "Health potion",Resource1.HealthPotion,  30, true);
            this.Inventory[1] = new Item.Item(20, "Health potion", Resource1.HealthPotion, 30, true);
            this.Inventory[2] = new Item.Item(20, "Health potion", Resource1.HealthPotion, 30, true);
            this.Inventory[3] = new Item.Item(20, "Health potion", Resource1.HealthPotion, 30, true);
        }
        public bool Interaction { get; private set; }
        public IItem[] Inventory { get; private set; }


        // Methods
        public void Buy()
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
