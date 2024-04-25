using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    internal class StartScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine("\n1. 상태 보기\n2. 인벤토리\n3. 상점\n4. 던전 입장\n5. 휴식하기");

                switch (Program.sceneManager.GetUserInput(5))
                {
                    case 0:
                        return;
                    case 1:
                        Program.sceneManager.ChangeScene("StatusScene");
                        break;
                    case 2:
                        Program.sceneManager.ChangeScene("InventoryScene");
                        break;
                    case 3:
                        Program.sceneManager.ChangeScene("ShopScene");
                        break;
                    case 4:
                        Program.sceneManager.ChangeScene("DungeonScene");
                        break;
                    case 5:
                        Program.sceneManager.ChangeScene("RestScene");
                        break;
                }
            }
        }
    }
}
