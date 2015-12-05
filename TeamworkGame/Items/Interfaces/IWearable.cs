using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkGame.Items
{
    interface IWearable
    {
        void Equip();
        void Unequip();
        void Remove();
        
    }
}
