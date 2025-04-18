using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    enum ShopState
    {
        Exit,
        Buy,
        Sell,
    }
    internal class Shop : CodeSystem
    {
        public List<Item> shopItem = new List<Item>();
        ShopState state = ShopState.Exit;
        
        public void ShopReset(Item[] item)
        {
            Random rand = new Random();
            for (int i = 0; i < 9; i++)
            {
                int randomItem = rand.Next(0, item.Length);
                shopItem.Add(new Item(item[randomItem]));
            }
        }

        public void Show(ref Player user)
        {
            switch (state)
            {
                case ShopState.Exit:
                case ShopState.Buy:
                    Console.WriteLine("[상점 아이템 목록]");
                    ShopOpen();
                    Console.Write("\n");
                    break;

                case ShopState.Sell:
                    Console.WriteLine("[보유 아이템 목록]");
                    user.inventory.OpenItem();
                    Console.Write("\n");
                    break;

            }
            
            switch (state)
            {
                case ShopState.Exit:
                    Console.WriteLine("[[상점]]");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다");
                    Console.Write("\n");
                    break;
                case ShopState.Buy:
                    Console.WriteLine("[[아이템 구매]]");
                    Console.WriteLine("상점에서 구매할 아이템을 선택해주세요");
                    Console.Write("\n");
                    break;
                case ShopState.Sell:
                    Console.WriteLine("[[아이템 판매]]");
                    Console.WriteLine("아이템을 선택하여 판매하면 정가의 85%를 드립니다.");
                    Console.Write("\n");
                    break; 

            }

            Console.WriteLine($"보유 금액 : {user.haveGold}G");
            Console.Write("\n");
        }

        public void Section()
        {
            switch (state)
            {
                case ShopState.Exit:
            Console.WriteLine("1. [아이템 구매]");
            Console.WriteLine("2. [아이템 판매]");
            Console.Write("\n");
                    break;
                case ShopState.Buy:
            Console.WriteLine("구매할 아이템의 번호를 눌러주세요");
            Console.Write("\n");
                    break;
                case ShopState.Sell:
            Console.WriteLine("판매할 아이템의 번호를 눌러주세요");
            Console.Write("\n");
                    break;
            }
            Console.WriteLine("0. [나가기]");
            Console.Write("\n");
        }

        public void Select(out PlaceType place, ref Player user)
        {
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            int check = 0;

            while (true)
            {
                Console.Write(">> ");
                check = TextInput();

                place = PlaceType.Shop;
                switch (state)
                {
                    case ShopState.Exit:
                        
                        switch (check)
                        {
                            case 1:
                                Console.WriteLine("[아이템 구매]를 선택하셨습니다.");
                                Console.Write("\n");
                                state = ShopState.Buy;
                                //ItemBuy(); 나중에 아이템 리스트 만들고 제작 예정
                                break;
                            case 2:
                                Console.WriteLine("[아이템 판매]를 선택하셨습니다.");
                                Console.Write("\n");
                                state = ShopState.Sell;
                                break;

                            case 0:
                                Console.WriteLine("[나가기]를 선택하셨습니다.");
                                Console.Write("\n");
                                state = ShopState.Exit;
                                place = PlaceType.Village;
                                break;
                            default:
                                Console.WriteLine("값을 다시 입력해주십시오");
                                continue;
                            }
                        Console.Write("\n");
                        break;

                    case ShopState.Buy:
                        if (check == 0)
                        {
                            Console.WriteLine("[나가기]를 선택하셨습니다.");
                            Console.Write("\n");
                            state = ShopState.Exit;
                        }
                        else if (check > 0 && check < shopItem.Count+1)
                        {
                            
                            int indexcheck = check - 1;
                            int price = shopItem[indexcheck].price;

                            Console.WriteLine("[아이템 구매]를 선택하셨습니다.");
                            
                            if (user.haveGold >= price)
                            {
                                user.inventory.ItemAdd(shopItem[indexcheck]);
                                user.haveGold -= price;
                                Console.WriteLine($"[{shopItem[indexcheck].itemName}]의 구매가 성공적으로 완료되었습니다.");
                                shopItem.RemoveAt(indexcheck);
                            }
                            else
                            {
                                Console.WriteLine("금액이 부족하여 구매를 실패하셨습니다.");
                            }
                            
                            Console.Write("\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("값을 다시 입력해주십시오");
                            continue;
                        }
                        break;

                    case ShopState.Sell:

                        if (check > 0 && check < user.inventory.Item.Count+1)
                        {
                            int indexCheck = check - 1;

                            if (user.inventory.Item[indexCheck].isEquip == true)
                            {
                                user.inventory.Equip(user.inventory.Item[indexCheck]);
                                Console.WriteLine("장비 착용이 해제되었습니다.");
                            }
                            
                            user.haveGold += (int)(user.inventory.Item[indexCheck].price * 0.85f);
                            Console.WriteLine($"[{user.inventory.Item[indexCheck].itemName}]의 판매가 성공적으로 완료되었습니다.");
                            user.inventory.Item.RemoveAt(indexCheck);
                        }
                        else if (check == 0)
                        {
                            Console.WriteLine(">> [나가기]를 선택하셨습니다.");
                            Console.Write("\n");
                            state = ShopState.Exit;
                        }
                        else
                        {
                            Console.WriteLine(">> 값을 다시 입력해주십시오");
                            continue;
                        }

                        break;
                }
                return;
            }
        }

        void ShopOpen()
        {
            for (int i = 0; i < shopItem.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                shopItem[i].ItemInfo();
            }
        }
        public Shop() { }

        public void StartShop(out PlaceType place, ref Player user)
        {
            Show(ref user);
            Section();
            Select(out place, ref user);
        }
    }
}
