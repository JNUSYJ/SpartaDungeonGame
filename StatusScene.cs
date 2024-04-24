using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    internal class StatusScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상태 보기\n캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine("Lv. {0}", Program.character.level.ToString("D2"));
                Console.WriteLine("{0} ( {1} )", Program.character.name, Program.character.job);
                Console.WriteLine("공격력 : {0} {1}", Program.character.atk, (Program.character.enhAtk > 0) ? "(+" + Program.character.enhAtk + ")" : "");
                Console.WriteLine("방어력 : {0} {1}", Program.character.amr, (Program.character.enhAmr > 0) ? "(+" + Program.character.enhAmr + ")" : "");
                Console.WriteLine("체 력 : {0}", Program.character.hp);
                Console.WriteLine("Gold : {0}", Program.character.gold);
                Console.WriteLine("\n0. 나가기");

                switch (Program.sceneManager.GetUserInput(0))
                {
                    case 0:
                        return;
                }
            }
        }
    }
}