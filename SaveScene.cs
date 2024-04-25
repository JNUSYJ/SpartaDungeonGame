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
            Console.Clear();
            Console.WriteLine("저장\n");
            Console.WriteLine(Program.character.ToString);

            Program.sceneManager.GetUserInput(0);

        }
    }
}
