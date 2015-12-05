using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkGame.Items
{
    class Necklace : Amulet
    {

        public Necklace(System.Drawing.Bitmap appearence, int increment )
            : base("Necklace of Wrath", increment, appearence)
        {
                
        }

        public override void Equip()
        {
            base.Equip(); // Increase character's health bar by 100, attack by 10 and speed by 5; price 1000 gold
        } 
    }
}
