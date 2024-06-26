﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    internal class InventoryScene : Scene
    {
        public override void RunScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");
                for (int i = 0; i < Program.character.inventory.Count; i++)
                {
                    Console.WriteLine(
                            "- {0}{1}| {2} | {3}",
                            (Program.character.inventory[i].isEquiped) ? "[E]" : "",
                            Program.character.inventory[i].name,
                            (Program.character.inventory[i].part.Equals("무기")) ? "공격력 +" + Program.character.inventory[i].atk : "방어력 +" + Program.character.inventory[i].amr,
                            Program.character.inventory[i].description
                            );
                }
                Console.WriteLine("\n1. 장착 관리\n0. 나가기");

                switch (Program.sceneManager.GetUserInput(1))
                {
                    case 0:
                        return;
                    case 1:
                        Program.sceneManager.ChangeScene("EquipScene");
                        break;
                }
            }
        }
    }
}
