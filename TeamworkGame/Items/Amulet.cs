using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkGame.Items
{
   abstract class Amulet : Item, IWearable
    {
       public Amulet(string name, int increment, System.Drawing.Bitmap appearence) : base (name, increment, appearence)
       {

       }

        public virtual void Equip()
        {
            throw new NotImplementedException();//Equip charachter with an amulet, increasing his abilities 
        }

        public void Unequip() // Unequip character, decreasing his abilities
        {
            throw new NotImplementedException();
        }

        public void Remove() //Remove amulet from the inventory
        {
            throw new NotImplementedException();
        }
    }
}
