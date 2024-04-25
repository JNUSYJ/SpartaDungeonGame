using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class ShopItem : Item
    {
        public bool isSold;

        public ShopItem(string name, string part, string description, float atk, float amr, int price, bool isSold) : base(name, part, description, atk, amr, price)
        {
            this.isSold = isSold;
        }
    }
}
