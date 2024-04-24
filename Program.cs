namespace SpartaDungeonGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            Character character = new Character();
            Shop shop = new Shop();
            while (true)
            {
                prog.Start(ref character, ref shop);
            }
        }

        void Start(ref Character character, ref Shop shop)
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("\n1. 상태 보기\n2. 인벤토리\n3. 상점\n");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            int act = int.Parse(Console.ReadLine());
            switch (act)
            {
                case 1:
                    ShowStatus(ref character);
                    break;
                case 2:
                    ShowInventory(ref character);
                    break;
                case 3:
                    ShowShop(ref character, ref shop);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }

        void ShowStatus(ref Character character)
        {
            Console.Clear();
            Console.WriteLine("상태 보기\n캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine("Lv. {0}", character.level.ToString("D2"));
            Console.WriteLine("{0} ( {1} )", character.name, character.job);
            Console.WriteLine("공격력 : {0} {1}", character.atk, (character.enhAtk > 0) ? "(+" + character.enhAtk + ")" : "");
            Console.WriteLine("방어력 : {0} {1}", character.amr, (character.enhAmr > 0) ? "(+" + character.enhAmr + ")" : "");
            Console.WriteLine("체 력 : {0}", character.hp);
            Console.WriteLine("Gold : {0}", character.gold);
            Console.Write("\n0. 나가기\n\n원하시는 행동을 입력해주세요.\n>> ");
            int act = int.Parse(Console.ReadLine());
            switch (act)
            {
                case 0:
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }

        void ShowInventory(ref Character character)
        {
            Console.Clear();
            Console.WriteLine("인벤토리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");
            for (int i = 0; i < character.inventory.Count; i++)
            {
                Console.WriteLine(
                        "- {0}{1}| {2} | {3}",
                        (character.inventory[i].isEquiped) ? "[E]" : "",
                        character.inventory[i].name,
                        (character.inventory[i].atk > 0) ? "공격력 +" + character.inventory[i].atk : "방어력 +" + character.inventory[i].amr,
                        character.inventory[i].description
                        );
            }
            Console.Write("\n1. 장착 관리\n0. 나가기\n\n원하시는 행동을 입력해주세요\n>> ");
            int act = int.Parse(Console.ReadLine());
            switch (act)
            {
                case 1:
                    SetEquip(ref character);
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
        }

        void SetEquip(ref Character character)
        {
            int act = 1;
            while (act != 0)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");
                for (int i = 0; i < character.inventory.Count; i++)
                {
                    Console.WriteLine(
                        "- {0} {1}{2}| {3} | {4}",
                        i + 1,
                        (character.inventory[i].isEquiped) ? "[E]" : "",
                        character.inventory[i].name,
                        (character.inventory[i].atk > 0) ? "공격력 +" + character.inventory[i].atk : "방어력 +" + character.inventory[i].amr,
                        character.inventory[i].description
                        );
                }
                Console.Write("\n0. 나가기\n\n원하시는 행동을 입력해주세요\n>> ");
                act = int.Parse(Console.ReadLine());
                if (0 < act && act <= character.inventory.Count)
                {
                    if (!character.inventory[act - 1].isEquiped)
                        character.EquipItem(act - 1);
                    else character.UnequipItem(act - 1);
                }
                else
                {
                    switch (act)
                    {
                        case 0:
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                    break;
                }
            }
        }

        void ShowShop(ref Character character, ref Shop shop)
        {
            Console.Clear();
            Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]");
            Console.WriteLine("{0} G", character.gold);
            Console.WriteLine("\n[아이템 목록]");
            for (int i = 0; i < shop.product.Count; i++)
            {
                Console.WriteLine("- {0} | {1} | {2} | {3}",
                    shop.product[i].name,
                    (shop.product[i].atk > 0) ? "공격력 +" + shop.product[i].atk : "방어력 +" + shop.product[i].amr,
                    shop.product[i].description,
                    (shop.product[i].isSold) ? "구매완료" : shop.product[i].price + " G"
                    );
            }
            Console.Write("\n1. 아이템 구매\n0. 나가기\n\n원하시는 행동을 입력해주세요\n>> ");
            int act = int.Parse(Console.ReadLine());
            switch (act)
            {
                case 1:
                    BuyShop(ref character, ref shop);
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

        }

        void BuyShop(ref Character character, ref Shop shop)
        {
            int act = 1;
            while (act != 0)
            {
                Console.Clear();
                Console.WriteLine("상점\n필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]");
                Console.WriteLine("{0} G", character.gold);
                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < shop.product.Count; i++)
                {
                    Console.WriteLine("- {0} {1} | {2} | {3} | {4}",
                        i + 1,
                        shop.product[i].name,
                        (shop.product[i].atk > 0) ? "공격력 +" + shop.product[i].atk : "방어력 +" + shop.product[i].amr,
                        shop.product[i].description,
                        (shop.product[i].isSold) ? "구매완료" : shop.product[i].price + " G"
                        );
                }
                Console.Write("\n0. 나가기\n\n원하시는 행동을 입력해주세요\n>> ");
                act = int.Parse(Console.ReadLine());
                if (0 < act && act <= shop.product.Count)
                    shop.BuyItem(ref character, act - 1);
                else
                {
                    switch (act)
                    {
                        case 0:
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            break;
                    }
                    break;
                }
            }
        }
    }

    public class Character
    {
        public int level, atk, enhAtk, amr, enhAmr, hp, gold;
        public string name, job;
        public List<MyItem> inventory;

        public Character()
        {
            level = 1; atk = 10; enhAtk = 0; amr = 5; enhAmr = 0; hp = 100; gold = 1500; name = "chad"; job = "전사";
            inventory = new List<MyItem>();
        }

        public void EquipItem(int index)
        {
            if (inventory[index] != null && !inventory[index].isEquiped)
            {
                inventory[index].isEquiped = true;
                atk += inventory[index].atk;
                enhAtk += inventory[index].atk;
                amr += inventory[index].amr;
                enhAmr += inventory[index].amr;
            }
        }
        public void UnequipItem(int index)
        {
            if (inventory[index] != null && inventory[index].isEquiped)
            {
                inventory[index].isEquiped = false;
                atk -= inventory[index].atk;
                enhAtk -= inventory[index].atk;
                amr -= inventory[index].amr;
                enhAmr -= inventory[index].amr;
            }
        }
    }

    public class Item
    {
        public int atk, amr, price;
        public string name, description;

        public Item(string name, string description, int atk, int amr, int price)
        {
            this.name = name;
            this.description = description;
            this.atk = atk;
            this.amr = amr;
            this.price = price;
        }
    }

    public class MyItem : Item
    {
        public bool isEquiped;

        public MyItem(string name, string description, int atk, int amr, int price, bool isEquiped) : base(name, description, atk, amr, price)
        {
            this.isEquiped = isEquiped;
        }
    }

    public class ShopItem : Item
    {
        public bool isSold;

        public ShopItem(string name, string description, int atk, int amr, int price, bool isSold) : base(name, description, atk, amr, price)
        {
            this.isSold = isSold;
        }
    }

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

        public void BuyItem(ref Character character, int index)
        {
            if (product[index] != null && product[index].isSold)
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
            else
            {
                if (character.gold >= product[index].price)
                {
                    Console.WriteLine("구매를 완료했습니다.");
                    character.gold -= product[index].price;
                    character.inventory.Add(new MyItem(product[index].name, product[index].description, product[index].atk, product[index].amr, product[index].price, false));
                    product[index].isSold = true;
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다.");
                }
            }
        }
    }
}
