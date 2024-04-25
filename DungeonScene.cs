using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    internal class DungeonScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("던전 입장\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
                for (int i = 0; i < Program.dungeons.list.Count(); i++)
                {
                    Console.WriteLine("{0}. {1} | 방어력 {2} 이상 권장",
                        i + 1,
                        Program.dungeons.list[i].dungeonName,
                        Program.dungeons.list[i].requiredAmr
                        );
                }
                Console.WriteLine("\n0. 나가기");

                int input = Program.sceneManager.GetUserInput(Program.dungeons.list.Count());
                switch (input)
                {
                    case 0:
                        return;
                    default:
                        if (0 < input && input <= Program.dungeons.list.Count())
                        {
                            Program.dungeons.EnterDungeon(input - 1);
                            Program.sceneManager.ChangeScene("DungeonRewardScene");
                        }
                        break;
                }
            }
        }
    }
}
