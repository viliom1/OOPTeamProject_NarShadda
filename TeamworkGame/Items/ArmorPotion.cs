using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkGame.Items
{
    class ArmorPotion : Potion
    {

        public ArmorPotion(System.Drawing.Bitmap appearence)
            : base("Armor Potion", 50, appearence)
        {

        }

        public override void Drink()
        {
            base.Drink();//Character get shield that absorbs 50 dmg; price 50 gold
        }

    }
}
