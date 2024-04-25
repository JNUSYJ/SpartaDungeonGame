using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Item
    {
        [JsonInclude]
        public float atk, amr;
        [JsonInclude]
        public int price;
        [JsonInclude]
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
