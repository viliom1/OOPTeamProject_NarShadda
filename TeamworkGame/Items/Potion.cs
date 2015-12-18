using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TeamworkGame.Items
{
    class Potion : IDrinkable
    {
        public Potion(string name, int increment, System.Drawing.Bitmap appearence)
            : base(name, increment, appearence)
        {

        }

        public virtual void Drink()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
