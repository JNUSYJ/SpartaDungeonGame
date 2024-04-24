using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeonGame
{
    public class Shop
    {
        public List<ShopItem> product;

        public Shop()
        {
            product =
            [
                new ShopItem("수련자 갑옷", "방어구", "수련에 도움을 주는 갑옷입니다.", 0, 5, 1000, false),
                new ShopItem("무쇠 갑옷", "방어구", "수련에 도움을 주는 갑옷입니다.", 0, 9, 2500, false),
                new ShopItem("스파르타의 갑옷", "방어구", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 15, 3500, false),
                new ShopItem("낡은 검", "무기", "쉽게 볼 수 있는 낡은 검입니다.", 2, 0, 600, false),
                new ShopItem("청동 도끼", "무기", "어디선가 사용됐던 거 같은 도끼입니다.", 5, 0, 1500, false),
                new ShopItem("스파르타의 창", "무기", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0, 2100, false),
                new ShopItem("영주의 검", "무기", "그 영주가 아니라 실명이 영주인 사람이 쓴 검입니다.", 10, 0, 3000, false)
            ];
        }

        public void BuyItem(int input)
        {
            if (product[input].isSold)
            {
               Program.systemMessage.SetMessage("이미 구매한 아이템입니다.");
            }
            else
            {
                if (Program.character.gold >= product[input].price)
                {
                    Program.character.gold -= product[input].price;
                    Program.character.inventory.Add(new MyItem(product[input].name,
                        product[input].part,
                        product[input].description, product[input].atk,
                        product[input].amr,
                        product[input].price,
                        false));
                    product[input].isSold = true;
                    Program.systemMessage.SetMessage("구매를 완료했습니다.");
                }
                else
                {
                    Program.systemMessage.SetMessage("Gold 가 부족합니다.");
                }
            }
        }
        
        public void SellItem(int input)
        {
            if (Program.character.inventory[input].isEquiped)
                Program.character.UnequipItem(input);
            Program.character.gold += (int)(Program.character.inventory[input].price * 0.85);
            Program.character.inventory.RemoveRange(input, 1);
            Program.systemMessage.SetMessage("판매를 완료했습니다.");
        }
    }
}
