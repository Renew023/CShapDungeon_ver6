namespace CshapDungeon_ver6
{

    internal class Item
    {
        public string itemName { get; set; }
        public StatType itemStatType { get; set; }
        public ItemType itemType { get; set; }
        public int stat { get; set; }
        public string itemHistory { get; set; }
        public int price { get; set; }

        public bool isEquip = false;

        //Item의 값을 참조가 아닌 값형으로 저장하기 위해서는
        //new Item으로 재선언할 필요가 있는데 데이터를 쉽게 저장하기 위해 선언 함수를 만들어주었다.
        public Item()
        {
        }

        public Item(Item item)
        {
            itemName = (string)item.itemName;
            itemStatType = (StatType)item.itemStatType;
            itemType = (ItemType)item.itemType;
            stat = (int)item.stat;
            itemHistory = (string)item.itemHistory;
            price = (int)item.price;
            isEquip = (bool)item.isEquip;
        }

        public Item(string newItemName, ItemType newItemType, StatType newItemStatType, int newStat, string newItemHistory, int newprice)
        {
            itemName = newItemName;
            itemType = newItemType;
            itemStatType = newItemStatType;
            stat = newStat;
            itemHistory = newItemHistory;
            price = newprice;
        }

        public void ItemInfo()
        {
            if (isEquip == true)
            {
                Console.Write("[E] ");
            }
            Console.WriteLine($"{itemName} || {itemType} || {itemStatType}: {stat} || {itemHistory} || {price}G");
        }
    }
}
