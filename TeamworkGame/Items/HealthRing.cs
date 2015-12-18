using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkGame.Items
{
    struct HealthRing 
    {
        public HealthRing(System.Drawing.Bitmap appearence) 
            : base ("Health Ring", 100, appearence) 
        {

        }

        public override void Equip()
        {
            base.Equip(); // Increase character's health bar by 100 price 400 gold
        }

    }
}
