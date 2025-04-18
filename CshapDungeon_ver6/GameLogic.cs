using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    public enum Job
    {
        Warrior = 1,
        Wizzard,
        Archor,
        NotJob
    }

    internal class GameLogic : CodeSystem
    {
        //생성자
        public Player user = new Player(); 
        PlaceType place = new PlaceType();
        ItemManager item = new ItemManager();

        Village village = new Village();
        Status status = new Status();
        OpenInventory inventory = new OpenInventory();
        Dungeon dungeon = new Dungeon();
        Shop shop = new Shop();
        Rest rest = new Rest();
        public DataManager data;

        public void Login()
        {
            Init();
            NameSelect();
            Console.Clear();
            JobSelect();
            Console.Clear();
        }

        public void NameSelect()
        {
            Console.WriteLine("스파르타 던전에 오신 것을 환영합니다.");
            Console.WriteLine("플레이어의 이름을 선택해주십시오.");
            Console.WriteLine("\n");

            while (true)
            {
                Console.Write(">> ");
                //내용 입력
                user.name = Console.ReadLine();
                Console.WriteLine("\n");

                //내용 확인
                Console.WriteLine($"플레이어가 입력한 이름은 \"{user.name}\" 입니다.");
                Console.Write("\n");

                //선택지
                Console.WriteLine("1. 저장");
                Console.WriteLine("2. 취소");
                Console.Write("\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");

                int check = 0;

                while (check != 2)
                {
                    check = TextInput();

                    switch (check)
                    {
                        case 1:
                            Console.WriteLine(">> 이름을 선택하셨습니다.");
                            return;

                        case 2:
                            Console.WriteLine(">> 이름을 다시 선택해주세요");
                            Console.WriteLine("\n");
                            break;

                        default:
                            Console.WriteLine(">> 값을 다시 입력해주십시오");
                            Console.WriteLine("\n");
                            continue;
                    }
                }
            }
        }

        public void JobSelect()
        {
            Console.WriteLine("\n");
            Console.WriteLine("직업을 선택해주세요.");
            Console.WriteLine("\n");
            Console.WriteLine("[1. 전사]");
            Console.WriteLine("[2. 마법사]");
            Console.WriteLine("[3. 궁수]");

            while (true)
            {
                Console.Write(">> ");
                //내용 입력
                int job = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                user.job = (Job)job;
                //내용 확인
                Console.Write($"플레이어는 ");
                switch (user.job)
                {
                    case Job.Warrior:
                        Console.WriteLine($"{user.job}을 선택했습니다.");
                        user.MaxHp = 25;
                        user.MaxAtk = 10;
                        user.MaxDef = 10;
                        break;
                    case Job.Wizzard:
                        Console.WriteLine($"{user.job}을 선택했습니다.");
                        user.MaxHp = 10;
                        user.MaxAtk = 20;
                        user.MaxDef = 10;
                        break;
                    case Job.Archor:
                        user.MaxHp = 15;
                        user.MaxAtk = 15;
                        user.MaxDef = 10;
                        Console.WriteLine($"{user.job}을 선택했습니다.");
                        break;
                    default:
                        Console.WriteLine($"값을 다시 입력해주십시오");
                        continue;
                }
                Console.Write("\n");

                //선택지
                Console.WriteLine("1. 저장");
                Console.WriteLine("2. 취소");
                Console.Write("\n");

                Console.WriteLine("원하시는 행동을 입력해주세요.");

                Console.Write(">> ");

                int check = 0;
                while (check != 2)
                {
                    check = int.Parse(Console.ReadLine());
                    switch (check)
                    {
                        case 1:
                            Console.WriteLine(">> 직업을 선택하셨습니다.");
                            LineTap(15);
                            return;
                        case 2:
                            Console.WriteLine(">> 직업을 다시 선택해주세요");
                            Console.WriteLine("\n");
                            break;

                        default:
                            Console.WriteLine(">> 값을 다시 입력해주십시오");
                            continue;
                    }
                }
            }
        }
        

        public void StartGame()
        {
            Console.Clear();
            switch (place)
            {
                case PlaceType.Reset:
                    Login();
                    break;

                case PlaceType.Village:
                    village.StartVillage(out place, ref user);
                    break;

                case PlaceType.Status:
                    status.StartStatus(out place, ref user);
                    //Status();

                    break;
                case PlaceType.Shop:
                    shop.StartShop(out place, ref user);
                    //Shop();
                    break;
                    
                case PlaceType.Inventory:
                    inventory.StartOpenInventory(out place, ref user);
                    //Inventory();

                    break;
                case PlaceType.Rest:
                    rest.StartRest(out place, ref user);
                    //Rest();

                    break;
                case PlaceType.Dungeon:
                    dungeon.StartDungeon(out place, ref user);
                    //Dungeon();
                    break;
            }
            GameOver();
            Thread.Sleep(500);
        }

        public void GameOver()
        {
            if (user.curHp < 0)
            {
                Console.WriteLine("게임이 종료되었습니다.");
                Console.Clear();
                Login();
            }
        }

        public void Init()
        {
            user = new Player();
            place = PlaceType.Village;
            user.job = Job.NotJob;
            shop = new Shop();
            shop.ShopReset(item.allItem);
        }
        

        public GameLogic()
        {
            Init();
        }
    }
}
