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
            product = new List<ShopItem>();
            product.Add(new ShopItem("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 0, 5, 1000, false));
            product.Add(new ShopItem("무쇠 갑옷", "수련에 도움을 주는 갑옷입니다.", 0, 9, 2500, false));
            product.Add(new ShopItem("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 15, 3500, false));
            product.Add(new ShopItem("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 2, 0, 600, false));
            product.Add(new ShopItem("청동 도끼", "어디선가 사용됐던 거 같은 도끼입니다.", 5, 0, 1500, false));
            product.Add(new ShopItem("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0, 2100, false));
        }

        public void BuyItem(ref Character character, int input)
        {
            if (product[input].isSold)
            {
               Program.systemMessage.SetMessage("이미 구매한 아이템입니다.");
            }
            else
            {
                if (character.gold >= product[input].price)
                {
                    character.gold -= product[input].price;
                    character.inventory.Add(new MyItem(product[input].name,
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
    }
}
