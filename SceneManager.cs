using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    internal class SceneManager
    {

        public SceneManager() { }

        public void ChangeScene(string sceneName)
        {
            Type sceneType = Type.GetType("SpartaDungeonGame." + sceneName);
            object obj = Activator.CreateInstance(sceneType);
        }

        public int GetUserInput(int maxNum)
        {
            Program.systemMessage.PrintMessage();
            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string s = Console.ReadLine();
            int input = -1;
            bool b = int.TryParse(s, out input);
            if (b && (0 <= input && input <= maxNum))
            {
                return input;
            }
            else
            {
                Program.systemMessage.SetMessage("잘못된 입력입니다.");
                return -1;
            }
        }
    }
}
