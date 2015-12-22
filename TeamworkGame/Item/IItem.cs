using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkGame.Item
{
    public interface IItem
    {
        int Increment { get; set; }
        string Name { get; set; }
        Bitmap Appearence { get; set; }
        int Price { get; set; }
        bool IsConsumable { get; set; }
    }
}
