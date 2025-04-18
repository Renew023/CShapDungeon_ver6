using CshapDungeon_ver6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    internal class Status : CodeSystem
    {
        public void Show(ref Player user)
        {
            //창 설명
            Console.WriteLine("[[상태 보기]]");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.Write("\n");

            user.ShowStatus();
            Console.Write("\n");
        }

        public void Section()
        {
            //선택지
            Console.WriteLine("0. 나가기");
            Console.Write("\n");
        }

        public void Select(out PlaceType place)
        {
            //플레이어 입력대기
            Console.WriteLine("원하시는 행동을 선택해주세요.");
            int check = 0;
            while (true)
            {

                check = TextInput();

                switch (check)
                {
                    case 0:
                        Console.WriteLine(">> 나가기를 선택하셨습니다.");
                        Console.Write("\n");

                        place = PlaceType.Village;
                        break;

                    default:
                        Console.WriteLine(">> 값을 다시 입력해주십시오");
                        Console.Write("\n");
                        continue;
                }
                return;
            }
        }
        
        public void StartStatus(out PlaceType place, ref Player user)
        {
            Show(ref user);
            Section();
            Select(out place);
        }

        public Status()
        {

        }
    }
}
