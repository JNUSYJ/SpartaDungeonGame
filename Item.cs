using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Item
    {
        public float atk, amr;
        public int price;
        public string name, part, description;

        public Item(string name, string part, string description, float atk, float amr, int price)
        {
            this.name = name;
            this.part = part;
            this.description = description;
            this.atk = atk;
            this.amr = amr;
            this.price = price;
        }
    }
}
