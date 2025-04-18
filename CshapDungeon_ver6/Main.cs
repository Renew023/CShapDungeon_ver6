using Newtonsoft.Json;

namespace CshapDungeon_ver6
{

    internal class Program
    {
        // 필요클래스 : 전부
        //1. Console.WriteLine이 활용된 라인들을 가독성을 위해 void 메서드로 데이터를 나누기
        //2. 중복된 내용을 void로 감싸고 필요한 경우 제너릭 또는 오버라이딩을 활용하여 데이터 값의 운용도 높이
        //3. 선택지 구문은 Enum 값을 활용하여 파트 나누기
        //4, 문법 뒤에 \n와 같이 가독성이 높아지는 코드를 넣을 수 있는 함수 만들기
        //5. For문을 메서드를 통해 활용하기
        //6. while문에서 3.에서 만든 Enum값을 활용하여 매칭 시스템 만들고
        //   0은 고정값이니 exit가 가능하도록 만든다.
        //7. 현재 나가기를 할 시에 village의 값을 매번 바꾸는데 그렇지 않고
        //   백업할 PlaceType을 만들어, 나가기를 누를 시 이전에 공간으로 바꿈.
        // 뜯어고칠 순서는 순차적으로 이름은 가독성을 높이기 위해 쓰지 않을 Enum형으로 하나 명시해주고
        // 공통 설명을 void로 진행


        static void Main(string[] args)
        {
            var code = new CodeSystem();
            var gameLogic = new GameLogic();

            LoadData(ref gameLogic);
            
            if(gameLogic.user.job == Job.NotJob)
            {
                gameLogic.Login(); 
            }

            PlaceType place = new PlaceType();

            while (true)
            {
                gameLogic.StartGame();
                SaveData(ref gameLogic);
                
            }

            static void SaveData(ref GameLogic gameLogic)
            {
                string filePath = "./Player.json";
                var testList = new Player(gameLogic.user);
                var jsonSerializeTestList = JsonConvert.SerializeObject(testList);
                File.WriteAllText(filePath, jsonSerializeTestList);
            }

            static void LoadData(ref GameLogic gameLogic)
            {
                string filePath = "./Player.json";
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    var jsonDeserializeList = JsonConvert.DeserializeObject<Player>(json);
                    gameLogic.user = jsonDeserializeList;
                }
            }

            //static void SaveData(ref GameLogic gameLogic)
            //{
            //    string FilePath = "./ItemData.json"; // 파일경로설정
            //    string FilePathPlayer = "./PlayerData.json";
            //    Console.WriteLine($"{FilePath}에 저장됨");
            //    try
            //    {
            //        var testList = new List<Item>();
            //        for(int i=0; i<gameLogic.user.inventory.Item.Count; i++)
            //        {
            //            testList.Add(new Item(gameLogic.user.inventory.Item[i]));
            //        }
            //        var jsonSerializeList = JsonConvert.SerializeObject(testList);
            //        var testListPlayer = new Player
            //        {
            //            name = gameLogic.user.name,
            //            job = gameLogic.user.job,
            //            level = gameLogic.user.level,
            //            exp = gameLogic.user.exp,
            //            curHp = gameLogic.user.curHp,
            //            curAtk = gameLogic.user.curAtk,
            //            curDef = gameLogic.user.curDef,
            //            maxHp = gameLogic.user.maxHp,
            //            maxAtk = gameLogic.user.maxAtk,
            //            maxDef = gameLogic.user.maxDef,
            //            haveGold = gameLogic.user.haveGold
            //        };
            //        var jsonSerializeListPlayer = JsonConvert.SerializeObject(testListPlayer);
            //        //string json = JsonConvert.SerializeObject(player, Newtonsoft.Json.Formatting.Indented);
            //        File.WriteAllText(FilePathPlayer, jsonSerializeListPlayer);
            //        File.WriteAllText(FilePath, jsonSerializeList);
                    
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error saving data: {ex.Message}");
            //    }
            //}

            //static void LoadData(ref GameLogic gameLogic)
            //{
            //    string FilePath = "./ItemData.json";
            //    string FilePathPlayer = "./PlayerData.json"; // 데이터 저장한 파일 경로 설정
            //    Console.WriteLine($"{FilePath}에서 불러오기 시도");
            //    try
            //    {
            //        if (File.Exists(FilePath))
            //        {
            //            string json = File.ReadAllText(FilePath);
            //            string json2 = File.ReadAllText(FilePathPlayer);
            //            List<Item> jsonDeserializeList = JsonConvert.DeserializeObject<List<Item>>(json);
            //            var jsonDeserializeList2 = JsonConvert.DeserializeObject<Player>(json2);

            //            gameLogic.user = jsonDeserializeList2;
            //            for (int i = 0; i < jsonDeserializeList.Count; i++)
            //            {
            //                gameLogic.user.inventory.Item.Add(new Item(jsonDeserializeList[i]));
            //            }
                        
            //        }
            //        else
            //        {
            //            // 파일 미 존재 시 기본 데이터 설정
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Error Load data: {ex.Message}");
            //        // JsonConver 오류 발생 시 기본 데이터 설정 
            //    }
            //}
        }
    }
}
