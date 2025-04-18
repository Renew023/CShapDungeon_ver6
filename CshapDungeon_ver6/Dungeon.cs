using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CshapDungeon_ver6
{
    internal class Dungeon : CodeSystem
    {
        int Easy = 5;
        int EasyGold = 1000;

        int Normal = 11;
        int NormalGold = 1500;

        int Hard = 17;
        int HardGold = 2000;

        public void StartDungeon(out PlaceType place, ref Player user)
        {
            Show(ref user);
            Section();
            Select(out place, ref user);
        }

        public void Show(ref Player user)
        {
            //창 설명
            Console.WriteLine("[[던전]]");
            Console.WriteLine("들어갈 던전의 난이도를 선택해주세요");
            Console.Write("\n");
            user.ShowStatus();
            Console.Write("\n");
            //상점의 정보
            Console.WriteLine("[던전별 난이도]");
            Console.WriteLine($"쉬운 던전 | 권장 난이도 {Easy}");
            Console.WriteLine($"일반 던전 | 권장 난이도 {Normal}");
            Console.WriteLine($"어려운 던전 | 권장 난이도 {Hard}");
            Console.Write("\n");
        }

        public void Section()
        {
            //선택지
            Console.WriteLine("1. [쉬운 던전]");
            Console.WriteLine("2. [일반 던전]");
            Console.WriteLine("3. [어려운 던전]");
            Console.WriteLine("0. [나가기]");
            Console.Write("\n");
        }

        public void Select(out PlaceType place, ref Player user)
        {
            //플레이어 입력대기
            while (true)
            {
                Console.WriteLine("원하시는 행동을 선택해주세요.");
                Console.Write(">> ");

                int num = TextInput();

                switch ((DungeonStage)num)
                {
                    case DungeonStage.Easy:
                    case DungeonStage.Normal:
                    case DungeonStage.Hard:
                        DungeonClear(num, ref user, out place);
                        return;
                    case 0:
                        Console.WriteLine("[나가기]를 선택하셨습니다.");
                        place = PlaceType.Village;
                        return;
                    default:
                        Console.WriteLine("재선택을 해주십시오.");
                        continue;
                }
            }
        }

        void DungeonClear(int dungeon, ref Player user, out PlaceType place)
        {
            float DungeonValue = 0;
            int clearGold = 0;
            float damage = 0;

            switch (dungeon)
            {
                case (int)DungeonStage.Easy:
                    DungeonValue = Easy;
                    clearGold = EasyGold;
                    break;
                case (int)DungeonStage.Normal:
                    DungeonValue = Normal;
                    clearGold = NormalGold;
                    break;

                case (int)DungeonStage.Hard:
                    DungeonValue = Hard;
                    clearGold = HardGold;
                    break;
            }

            float def = user.curDef;
            float atk = user.curAtk;

            bool isClear = false;

            if (def >= DungeonValue)
            {
                isClear = true;
            }
            else
            {
                Random rand = new Random();
                float fail = rand.Next(0, 100);

                if (fail < 40)
                {
                    damage = 50;
                    user.curHp -= damage;

                    user.ShowStatus((int)damage);
                    Console.WriteLine("던전 공략에 실패하셨습니다.");

                    GameOver(ref user, (int)damage, out place);
                    if (place == PlaceType.Village) return;
                }
                else
                {
                    isClear = true;
                }
            }

            if (isClear == true)
            {
                //기능먼저
                Random rand = new Random();
                damage = rand.Next(20, 35) + 1 - (def - 5);
                user.curHp -= damage;
                GameOver(ref user, (int)damage, out place);
                if (place == PlaceType.Village)
                { return; }

                //기능 후
                Console.WriteLine("[던전 클리어]");

                int percent = rand.Next(10, 20); // 1, 2
                user.haveGold = clearGold * (int)(atk * percent * 0.1f);
                
                user.ShowStatus((int)damage);

                Console.Write("\n");
                
                Console.WriteLine($"보상 : {clearGold}");
                Console.Write("\n");
                Thread.Sleep(500);
                user.DungeonClear();
            }

            Console.WriteLine("던전을 더 들어가시겠습니까?");
            Console.WriteLine("1. [재입장]");
            Console.WriteLine("0. [나가기]");
            Console.Write("\n");

            //플레이어 입력대기
            while (true)
            {
                Console.WriteLine("원하시는 행동을 선택해주세요.");

                int num = TextInput();

                switch (num)
                {
                    case 1:
                        Console.WriteLine("[재입장]을 선택하셨습니다.");
                        place = PlaceType.Dungeon;

                        return;
                    case 0:
                        Console.WriteLine("[나가기]를 선택하셨습니다.");
                        place = PlaceType.Village;
                        return;
                    default:
                        Console.WriteLine("재선택을 해주십시오.");
                        continue;
                }
            }
        }

        public void GameOver(ref Player user, int damage, out PlaceType place)
        {
            if (user.curHp < 0)
            {
                Console.Clear();
                Console.WriteLine("던전 공략 중 사망하셨습니다.");
                user.ShowStatus(damage);

                Console.WriteLine("아무 키나 눌러서 재시작");
                Console.Write("\n");
                Console.ReadLine();
                place = PlaceType.Village;
                return;
            }
            place = PlaceType.Dungeon;
        }
    }
}
