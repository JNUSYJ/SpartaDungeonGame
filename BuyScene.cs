using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    internal class BuyScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 구매\n필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]");
                Console.WriteLine("{0} G", Program.character.gold);
                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < Program.shop.product.Count; i++)
                {
                    Console.WriteLine("- {0} {1} | {2} | {3} | {4}",
                        i + 1,
                        Program.shop.product[i].name,
                        (Program.shop.product[i].atk > 0) ? "공격력 +" + Program.shop.product[i].atk : "방어력 +" + Program.shop.product[i].amr,
                        Program.shop.product[i].description,
                        (Program.shop.product[i].isSold) ? "구매완료" : Program.shop.product[i].price + " G"
                        );
                }
                Console.WriteLine("\n0. 나가기");

                int input = Program.sceneManager.GetUserInput(Program.shop.product.Count);
                switch (input)
                {
                    case 0:
                        return;
                    default:
                        if (0 < input && input < Program.shop.product.Count())
                        {
                            Program.shop.BuyItem(ref Program.character, input - 1);
                        }
                        break;
                }
            }
        }
    }
}
