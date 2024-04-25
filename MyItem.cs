using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class MyItem : Item
    {
        [JsonInclude]
        public bool isEquiped;

        public MyItem(string name, string part, string description, float atk, float amr, int price, bool isEquiped) : base(name, part, description, atk, amr, price)
        {
            this.isEquiped = isEquiped;
        }
    }
}
