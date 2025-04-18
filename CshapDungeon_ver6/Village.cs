using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    internal class Village : CodeSystem
    {
        public void Show()
        {
            Console.WriteLine("[[스파르타 마을]]에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할수 있습니다.");
            Console.Write("\n");
        }

        public void Section()
        {
            Console.WriteLine("1. [상태 보기]");
            Console.WriteLine("2. [인벤토리]");
            Console.WriteLine("3. [상점]");
            Console.WriteLine("4. [휴식처]");
            Console.WriteLine("5. [던전 입장]");
            Console.WriteLine("9. [계정 초기화]");
            Console.WriteLine("0. [게임 종료]");
            Console.Write("\n");
        }

        public void Select(out PlaceType place)
        {
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            int check = 0;

            while (true)
            {
                check = TextInput();

                if (check == 0)
                {
                    Environment.Exit(0);
                }

                switch ((PlaceType)check)
                {
                    case PlaceType.Reset:
                        Console.WriteLine(">> [계정초기화]를 선택하셨습니다.");
                        Console.Write("\n");

                        place = PlaceType.Reset;
                        return;

                    case PlaceType.Status:
                        Console.WriteLine(">> [상태보기]를 선택하셨습니다.");
                        Console.Write("\n");

                        place = PlaceType.Status;
                        return;

                    case PlaceType.Inventory:
                        Console.WriteLine(">> [인벤토리]를 선택하셨습니다.");
                        Console.Write("\n");

                        place = PlaceType.Inventory;
                        return;

                    case PlaceType.Shop:
                        Console.WriteLine(">> [상점]을 선택하셨습니다.");
                        Console.Write("\n");

                        place = PlaceType.Shop;
                        return;

                    case PlaceType.Rest:
                        Console.WriteLine(">> [휴식처]을 선택하셨습니다.");
                        Console.Write("\n");

                        place = PlaceType.Rest;
                        return;
                    case PlaceType.Dungeon:
                        Console.WriteLine(">> [던전입장]을 선택하셨습니다.");
                        Console.Write("\n");

                        place = PlaceType.Dungeon;
                        return;

                    default:
                        Console.WriteLine("값을 다시 입력해주십시오");
                        continue;
                }
            }
        }
        public Village()
        {

        }
        public void StartVillage(out PlaceType place, ref Player user)
        {
            Section();
            Show();
            Select(out place);
        }
    }
}
