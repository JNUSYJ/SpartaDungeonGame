using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    internal class DungeonRewardScene : Scene
    {
        public override void RunScene()
        {
            while(true)
            {
                Console.Clear();
                if (Program.dungeons.isSucceed)
                    Console.WriteLine("던전 클리어\n축하합니다!!\n{0}을 클리어하였습니다.", Program.dungeons.enteredDungeon);
                else
                    Console.WriteLine("던전 실패\n이런...!\n{0} 클리어에 실패하였습니다.", Program.dungeons.enteredDungeon);
                Console.WriteLine("[탐험결과]");
                Console.WriteLine("체력 {0} -> {1}", Program.dungeons.beforeHp, Program.character.hp);
                if (Program.dungeons.isSucceed) 
                    Console.WriteLine("Gold {0} G -> {1} G", Program.dungeons.beforeGold, Program.character.gold);
                Console.WriteLine("\n0. 나가기");

                switch(Program.sceneManager.GetUserInput(0))
                {
                    case 0:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
