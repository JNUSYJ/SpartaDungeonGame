﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class ShopItem : Item
    {
        public bool isSold;

        public ShopItem(string name, string description, int atk, int amr, int price, bool isSold) : base(name, description, atk, amr, price)
        {
            this.isSold = isSold;
        }
    }
}
