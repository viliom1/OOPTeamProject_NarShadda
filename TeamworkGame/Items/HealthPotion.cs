using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkGame.Items
{
    class HealthPotion : Potion
    {
        public HealthPotion(System.Drawing.Bitmap appearence)
            : base("Health Potion", 50, appearence)
        {

        }

        public override void Drink()
        {
            base.Drink();// Increase health by 50; price 50 gold
        }
    }
}
