using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    internal class RestScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("휴식하기\n500 G를 내면 체력을 회복할 수 있습니다. (보유골드 : {0} G)", Program.character.gold);
                Console.WriteLine("\n1. 휴식하기\n0. 나가기");

                switch (Program.sceneManager.GetUserInput(1))
                {
                    case 0:
                        return;
                    case 1:
                        if (Program.character.gold >= 500)
                        {
                            Program.character.gold -= 500;
                            Program.character.hp = 100;
                            Program.systemMessage.SetMessage("휴식을 완료했습니다.");
                        }
                        else
                            Program.systemMessage.SetMessage("Gold가 부족합니다.");
                        break;
                }
            }
        }
    }
}
