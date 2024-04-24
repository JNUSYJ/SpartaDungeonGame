using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    internal class SellScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 판매\n필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]");
                Console.WriteLine("{0} G", Program.character.gold);
                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < Program.character.inventory.Count; i++)
                {
                    Console.WriteLine("- {0} {1} | {2} | {3} | {4}",
                        i + 1,
                        Program.character.inventory[i].name,
                        (Program.shop.product[i].part.Equals("무기")) ? "공격력 +" + Program.character.inventory[i].atk : "방어력 +" + Program.character.inventory[i].amr,
                        Program.character.inventory[i].description,
                        (Program.character.inventory[i].price * 0.85) + " G"
                        );
                }
                Console.WriteLine("\n0. 나가기");

                int input = Program.sceneManager.GetUserInput(Program.character.inventory.Count);
                switch (input)
                {
                    case 0:
                        return;
                    default:
                        if (0 < input && input <= Program.character.inventory.Count())
                        {
                            Program.shop.SellItem(input - 1);
                        }
                        break;
                }
            }
        }
    }
}
