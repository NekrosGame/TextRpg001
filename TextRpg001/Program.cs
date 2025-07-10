using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace TextRpg001
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Story story = new Story(); // 스토리 클래스 인스턴스 생성

            string Name = story.StartStory(); // 스토리 시작 및 이름 입력
            Player player = new Player(Name); // 플레이어 클래스 인스턴스 생성

            while (true)
            {
                Console.WriteLine("[원하시는 행동을 입력해 주세요.]\n");
                Console.WriteLine("[1. 상태보기]");
                Console.WriteLine("[2. 인벤토리]");
                Console.WriteLine("[3. 상점]");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("상태 보기");
                        player.DisplayStatus();
                        break;
                    case "2":
                        Console.WriteLine("인벤토리");
                        Inventory inventory = new Inventory();
                        inventory.DisplayItems();
                        break;
                    case "3":
                        Console.WriteLine("상점");
                        Shop shop = new Shop(player);
                        shop.DisplayShop();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다");
                        break;
                }
            }
        }
    }

    internal class Player // 상태 클래스
    {
        public string PlayerName { get; set; }
        public int PlayerLevel { get; set; }
        public string PlayerJob { get; set; }
        public int PlayerAttack { get; set; }
        public int PlayerDefense { get; set; }
        public int PlayerHealth { get; set; }
        public int PlayerGold { get; set; }

        public Player(string name)
        {
            PlayerName = name;
            PlayerLevel = 01;
            PlayerJob = "전사(스켈레톤)";
            PlayerAttack = 10;
            PlayerDefense = 5;
            PlayerHealth = 100;
            PlayerGold = 1500;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"\n『");
            Console.WriteLine($"  이름: {PlayerName}");
            Console.WriteLine($"  레벨: {PlayerLevel}");
            Console.WriteLine($"  직업: {PlayerJob}");
            Console.WriteLine($"  공격력: {PlayerAttack}");
            Console.WriteLine($"  방어력: {PlayerDefense}");
            Console.WriteLine($"  체력: {PlayerHealth}");
            Console.WriteLine($"  Gold: {PlayerGold}");
            Console.WriteLine($"                           』");

            Console.WriteLine("\n[0. 나가기]");
            while (true)
            {
                string exitInput = Console.ReadLine();
                if (exitInput == "0")
                {
                    Console.WriteLine("당신은 시작 구역으로 되돌아 갔다.\n");
                    break; // while문을 빠져나가 메인 메뉴로 돌아감
                }
                else
                {
                    Console.WriteLine("\n[0. 나가기]");
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
        }
    }

    internal class Shop // 상점 클래스
    {
        private Player player; // 플레이어 인스턴스

        public Shop(Player player)
        {
            this.player = player; // 생성자에서 플레이어 인스턴스를 받아옴
        }

        public void DisplayShop()
        {
            int gold = player.PlayerGold; // 플레이어의 골드
            string[] itemNames = { "수련자 갑옷", "무쇠갑옷", "스파르타의 갑옷", "낡은 검", "청동 도끼", "스파르타의 창" };
            string[] itemStats = { "방어력 +5", "방어력 +9", "방어력 +15", "공격력 +2", "공격력 +5", "공격력 +7" };
            string[] itemDescs = {
                "수련에 도움을 주는 갑옷입니다.",
                "무쇠로 만들어져 튼튼한 갑옷입니다.",
                "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                "쉽게 볼 수 있는 낡은 검 입니다.",
                "어디선가 사용됐던거 같은 도끼입니다.",
                "스파르타의 전사들이 사용했다는 전설의 창입니다."
            };
            int[] itemGold = { 1000, 1200, 1500, 500, 700, 1300 };

            while (true)
            {
                Console.WriteLine("\n======================================================\n");
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine($"[보유 골드]\n{gold} G\n");
                Console.WriteLine("[아이템 목록]\n");
                for (int i = 0; i < itemNames.Length; i++)
                {
                    Console.WriteLine($"- {itemNames[i],-10}\t | {itemStats[i],-8}\t | {itemDescs[i], -8}\t | {itemGold[i]}");
                }
                Console.WriteLine();
                Console.WriteLine("[1. 아이템 구매]");
                Console.WriteLine("[0. 나가기]");

                string input = Console.ReadLine();
                if (input == "0")
                {
                    Console.WriteLine("상점에서 나갑니다.");
                    break;
                }
                else if (input == "1")
                {
                    // 구매 모드 진입
                    while (true)
                    {
                        Console.WriteLine("\n======================================================\n");
                        Console.WriteLine("[아이템 목록]\n");

                        for (int i = 0; i < itemNames.Length; i++)
                        {
                            Console.WriteLine($"- {i + 1}. {itemNames[i],-10}\t | {itemStats[i],-8}\t | {itemDescs[i],-8}\t | {itemGold[i]}");
                        }
                        Console.WriteLine("\n[0. 취소]");

                        string buyInput = Console.ReadLine();
                        if (buyInput == "0")
                        {
                            Console.WriteLine("구매를 취소합니다.\n");
                            break;
                        }
                        else if (int.TryParse(buyInput, out int itemNum) && itemNum >= 1 && itemNum <= itemNames.Length)
                        {
                            Console.WriteLine($"{itemNames[itemNum - 1]}을(를) 구매했습니다!\n");
                            // 실제 구매 로직(골드 차감, 인벤토리 추가 등) 구현 필요
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.\n");
                        }
                        Console.WriteLine("\n구매할 아이템의 번호를 입력하세요.");


                    }

                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.\n");
                }
            }
        }
    }


    internal class Inventory // 인벤토리 클래스
    {
        private List<string> items = new List<string>();

        public void AddItem(string itemName)
        {
            items.Add(itemName);
        }

        public void DisplayItems()
        {
            Console.WriteLine("[아이템 목록]\n");
            if (items.Count == 0)
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.\n");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"- {items[i]}");
                }
            }

            while (true)
            {
                Console.WriteLine("[1. 아이템 장착]");
                Console.WriteLine("[0. 나가기]\n");
                string input = Console.ReadLine();
                if (input == "0")
                {
                    Console.WriteLine("인벤토리에서 나갑니다.");
                    break;
                }
                else if (input == "1")
                {
                    Console.WriteLine("아이템을 장착합니다.");
                    // 아이템 장착 로직 추가
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
        }
    }


    internal class Story // 스토리 클래스
    {
        public string StartStory()
        {
            Console.WriteLine("어둡고 축축한 동굴");
            Console.WriteLine("벽에 붙은 횃불만이 밝게 빛나며 당신을 비춥니다.\n");
            Console.WriteLine("[1. 자신의 모습을 확인한다.]");

            string startInput = Console.ReadLine();
            if (startInput == "1")
            {
                Console.WriteLine("\n당신은 스스로를 바라봅니다.");
                Console.WriteLine("당신의 모습은 인간이라 보이지 않습니다.");
                Console.WriteLine("새하얀 백골...");
                Console.WriteLine("당신은 스스로 스켈레톤임을 깨닫습니다.");
            }
            else
            {
                Console.WriteLine("\n당신은 그런건 중요하지 않다고 생각합니다.");
            }

            Console.WriteLine("\n\"음… 나는 누구였지?\"\n");
            Console.WriteLine("당신은 왜 이런곳에 있었는지, 전혀 기억나지 않습니다.");
            Console.WriteLine("그나마 희미하게 남은 기억이 스스로의 이름을 떠올립니다.");
            Console.WriteLine("\n[당신의 이름은?]");

            string Name = Console.ReadLine();

            Console.WriteLine($"\n\"그래 내 이름은 {Name}(이)였지.\"\n");

            Console.WriteLine("당신은 우선 이곳을 돌아다녀 보고자 합니다.\n");

            return Name; // 이름을 반환하여 이후 다른 클래스에서 사용할 수 있도록 합니다.
        }

    }

}

