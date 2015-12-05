using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkGame.Items
{
    class PowerRing : Amulet
    {
        public PowerRing(System.Drawing.Bitmap appearence) 
            : base ("Power Ring", 10, appearence)
        {

        }

        public override void Equip()
        {
            base.Equip(); // Override to increase character's attack by 10; price 300 gold
        }
    }
}
