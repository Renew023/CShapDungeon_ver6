using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    public enum ItemType
    {
        Head = 0, //머리
        Body, //몸
        Hand, //손
        Reggings, //바지
        Shoes, //발
        Ring, //반지
        NeckRing //목걸이
    }
    public enum StatType //4주차
    {
        Hp = 0,     //체력
        Atk = 1,    //공격력
        Def = 2,    //방어력

    }

    public enum PlaceType //VillageSection
    {
        Status = 1, //능력치 확인
        Inventory = 2, //인벤토리
        Shop = 3, //상점
        Rest = 4, //휴식하기
        Dungeon = 5, //던전입장
        Reset = 9, // 게임시작
        Village = 0 //마을 
    }

    //장착개선에 쓰일 코드

    public enum DungeonStage
    {
        Easy = 1,
        Normal,
        Hard
    }
}
