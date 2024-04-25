using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpartaDungeonGame
{
    internal class LoadScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("불러오기\n불러올 저장 파일의 이름(번호X)을 입력해주세요.\n\n[저장 파일 목록]\n");
                string directory = ".\\..\\..\\..\\sav";
                DirectoryInfo di = new DirectoryInfo(directory);
                if(di.Exists && di.GetFiles() != null)
                {
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        Console.WriteLine(fi.Name);
                    }
                }
                Console.WriteLine("\n0. 나가기");

                string fileName = Program.sceneManager.GetUserInput();
                int exitNum = -1;
                bool exitCheck = int.TryParse(fileName, out exitNum);
                if (exitCheck && exitNum == 0)
                    return;
                else
                {
                    if (!exitCheck && !fileName.Equals("error"))
                        Program.fileControl.Load(fileName);
                }
            }
        }
    }
}
