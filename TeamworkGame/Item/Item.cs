using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkGame.Item
{
   public class Item : IItem
    {
        private int increment;
        private string name;
        private Bitmap appearence;
        private int price;

        public Item(int incement, string name, Bitmap appearance, int price,bool isConsumable)
        {
            this.Increment = incement;
            this.Name = name;
            this.Appearence = appearance;
            this.IsConsumable = isConsumable;
            this.Price = price;
        }

        public int Increment { get; set; }
        public bool IsConsumable { get; set; }

        public string Name { get; set; }
      

        public System.Drawing.Bitmap Appearence { get; set; }
      

        public int Price { get; set; }
        
    }
}
