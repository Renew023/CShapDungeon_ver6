using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CshapDungeon_ver6
{
    internal class ItemManager
    {

        public Item[] allItem = new Item[3]; //아이템 초기화 및 선언

        public void InitAllItem()
        {
            allItem[0] = new Item("호랑이의 팬티", ItemType.Reggings, StatType.Atk, 8, "호랑이의 털로 만든 팬티로 도깨비가 입고다닌다", 500);
            allItem[1] = new Item("고양이의 수염", ItemType.Head, StatType.Def, 10, "고양이가 털갈이할 때 실수로 털을 빼버렸다", 200);
            allItem[2] = new Item("고양이의 으르렁", ItemType.Head, StatType.Def, 12, "고양이의 으르렁을 따라할 수 있다", 600);
        }

        public void InitShopItem()
        {

        }

        public void Init()
        {
            InitAllItem();
        }

        public ItemManager()
        {
            Init();
        }

    }
}
