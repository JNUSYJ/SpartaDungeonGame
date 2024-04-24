using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Item
    {
        public int atk, amr, price;
        public string name, description;

        public Item(string name, string description, int atk, int amr, int price)
        {
            this.name = name;
            this.description = description;
            this.atk = atk;
            this.amr = amr;
            this.price = price;
        }
    }
}
