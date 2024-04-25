using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpartaDungeonGame
{
    internal class SaveScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("저장\n어떤 이름으로 저장하시겠습니까?");
                Console.WriteLine("\n0. 나가기");

                string fileName = Program.sceneManager.GetUserInput();
                int exitNum = -1;
                bool exitCheck = int.TryParse(fileName, out exitNum);
                if (exitCheck && exitNum == 0)
                    return;
                else
                {
                    if (!exitCheck && !fileName.Equals("error"))
                        Program.fileControl.Save(fileName);
                }
            }
        }
    }
}
