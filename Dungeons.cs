using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    internal class Dungeons
    {
        public List<Dungeon> list;
        public string enteredDungeon;
        public bool isSucceed;
        public int beforeHp, penaltyHp;
        public int beforeGold, earnedGold;
        int input;

        public Dungeons() 
        {
            list = [
                new Dungeon("쉬운 던전", 5f),
                new Dungeon("일반 던전", 11f),
                new Dungeon("어려운 던전", 17f)
            ];
        }

        public void EnterDungeon(int input)
        {
            enteredDungeon = list[input].dungeonName;
            beforeHp = Program.character.hp;
            beforeGold = Program.character.gold;

            this.input = input;
            if (Program.character.amr < list[input].requiredAmr)
            {
                Random random = new Random();
                if (random.Next(100) < 40)
                    DungeonFailed();
                else
                    DungeonSucceed();

            }
            else
            {
                DungeonSucceed();
            }
        }

        public void DungeonFailed()
        {
            isSucceed = false;
            penaltyHp = Program.character.hp / 2;
            Program.character.hp -= penaltyHp;
            if (Program.character.hp < 1)
                Program.character.hp = 1;
            earnedGold = 0;
        }

        public void DungeonSucceed()
        {
            isSucceed = true;
            Random random = new Random();
            penaltyHp = (20 + (int)(list[input].requiredAmr - Program.character.amr) + random.Next(15));
            Program.character.hp -= penaltyHp;
            if (Program.character.hp < 1)
                Program.character.hp = 1;
            int clearGold = 0;
            if (input == 0) clearGold = 1000;
            else if (input == 1) clearGold = 1700;
            else if (input == 2) clearGold = 2500;
            random = new Random();
            earnedGold = (int)(clearGold + clearGold * random.Next((int)Program.character.atk, (int)Program.character.atk * 2) * 0.01f);
            Program.character.gold += earnedGold;
            Program.character.ExpUp(1);
        }
    }
}
