using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    enum InventoryState
    {
        Exit = 0,
        Equip = 1
    }

    internal class OpenInventory : CodeSystem
    {
        InventoryState state = InventoryState.Exit;

        public void StartOpenInventory(out PlaceType place, ref Player user)
        {
            Show(ref user);
            Section();
            Select(out place, ref user);
        }
        //창 설명
        public void Show(ref Player user)
        {
            switch (state)
            {
                case InventoryState.Exit:
                    Console.WriteLine("[[인벤토리]]");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                    Console.Write("\n");
                    break;
                case InventoryState.Equip:
                    Console.WriteLine("[[아이템 장착]]");
                    Console.WriteLine("원하는 아이템을 장착할 수 있습니다.");
                    Console.Write("\n");
                    break;
            }
            //플레이어의 정보 : 장착 아이템
            Console.WriteLine("[장착중인 아이템]");
            for (int i = 0; i < user.inventory.Item.Count; i++)
            {
                if (user.inventory.Item[i].isEquip == true)
                {
                    user.inventory.Item[i].ItemInfo();
                }
            }
            LineTap(2);
            //보유 아이템
            Console.WriteLine("[보유 아이템]");
            for (int i = 0; i < user.inventory.Item.Count; i++)
            {
                Console.Write($"[{i + 1}] ");
                user.inventory.Item[i].ItemInfo();
            }
            LineTap(2);
        }

        public void Section()
        {
            //선택지
            switch (state)
            {
                case InventoryState.Exit:
                Console.WriteLine("1. [장착하기]");
                Console.WriteLine("0. [나가기]");
                Console.Write("\n");
                    break;
                case InventoryState.Equip:
                    Console.WriteLine("장착하고 싶은 번호의 아이템을 입력해주세요");
                    Console.WriteLine("0. [나가기]");
                    Console.Write("\n");
                    break;

            
            }
            LineTap(2);
        }

        public void Select(out PlaceType place, ref Player user)
        {
            //플레이어 입력대기
            Console.WriteLine("원하시는 행동을 선택해주세요.");

            while (true)
            {
                int check = TextInput();
                place = PlaceType.Inventory;

                switch ((InventoryState)state)
                {
                    case InventoryState.Exit:

                        switch (check)
                        {
                            case 0:
                                Console.WriteLine(">> [나가기]를 선택하셨습니다.");
                                Console.Write("\n");
                                place = PlaceType.Village;
                                return;

                            case 1:
                                Console.WriteLine(">> [장착하기]를 선택하셨습니다.");
                                Console.Write("\n");
                                state = InventoryState.Equip;

                                //Equip(); 근데 이거는 Item을 리스트에 넣어줘야 되기 때문에 보류;

                                break;

                            default:
                                Console.WriteLine(">> 값을 다시 입력해주십시오");
                                continue;
                        }
                        break;

                    case InventoryState.Equip:

                            if (check > 0 && check <= user.inventory.Item.Count)
                            {
                                user.inventory.Equip(user.inventory.Item[check - 1]);
                                break;
                            }
                            else if (check == 0)
                            {
                                Console.WriteLine(">> [나가기]를 선택하셨습니다.");
                                Console.Write("\n");
                                place = PlaceType.Inventory;
                                state = InventoryState.Exit;
                                return;
                            }
                            else
                            {
                                Console.WriteLine(">> 값을 다시 입력해주십시오");
                                continue;
                            }

                        }

                        break;
                }
            }

        }
    }
