using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Character
    {
        public int level, hp, gold, exp, requiredExp;
        public float atk, enhAtk, amr, enhAmr;
        public string name, job;
        public List<MyItem> inventory;

        public Character()
        {
            level = 1; atk = 10f; enhAtk = 0f; amr = 5f; enhAmr = 0f; hp = 100; gold = 15000; name = "chad"; job = "전사";
            inventory = new List<MyItem>();
            exp = 0; requiredExp = 1;
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

        public void ExpUp(int exp)
        {
            if (exp <= 0) return;
            this.exp += exp;
            while (this.exp >= requiredExp)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
            exp -= requiredExp;
            level++;
            requiredExp++;
            atk += 0.5f;
            amr += 1f;
        }
    }
}
