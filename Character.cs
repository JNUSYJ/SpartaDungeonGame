using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Character
    {
        public int level, atk, enhAtk, amr, enhAmr, hp, gold;
        public string name, job;
        public List<MyItem> inventory;

        public Character()
        {
            level = 1; atk = 10; enhAtk = 0; amr = 5; enhAmr = 0; hp = 100; gold = 1500; name = "chad"; job = "전사";
            inventory = new List<MyItem>();
        }

        public void EquipItem(int index)
        {
            if (inventory[index] != null && !inventory[index].isEquiped)
            {
                inventory[index].isEquiped = true;
                atk += inventory[index].atk;
                enhAtk += inventory[index].atk;
                amr += inventory[index].amr;
                enhAmr += inventory[index].amr;
            }
        }
        public void UnequipItem(int index)
        {
            if (inventory[index] != null && inventory[index].isEquiped)
            {
                inventory[index].isEquiped = false;
                atk -= inventory[index].atk;
                enhAtk -= inventory[index].atk;
                amr -= inventory[index].amr;
                enhAmr -= inventory[index].amr;
            }
        }
    }
}
