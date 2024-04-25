using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    internal class Dungeon
    {
        public string dungeonName;
        public int requiredAmr;

        public Dungeon(string dungeonName, int requiredAmr)
        {
            this.dungeonName = dungeonName;
            this.requiredAmr = requiredAmr;
        }
    }
}
