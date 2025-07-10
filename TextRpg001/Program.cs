using System.Xml.Linq;

namespace TextRpg001
{
    internal class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine("\n당신은 그런게 중요하지 않다고 생각합니다.");
            }

            Console.WriteLine("\n\"음… 나는 누구였지?\"\n");
            Console.WriteLine("당신은 왜 이런곳에 있었는지, 전혀 기억나지 않습니다.");
            Console.WriteLine("그나마 희미하게 남은 기억이 스스로의 이름을 떠올립니다.");
            Console.WriteLine("\n[당신의 이름은?]");

            string Name = Console.ReadLine();

            Console.WriteLine($"\n\"그래 내 이름은 {Name}(이)였지.\"\n");

            Console.WriteLine("당신은 우선 이곳을 돌아다녀 보고자 합니다.\n");
            // 위에 내용 까지는 최초 1회만 실행되어야함.
            

            Console.WriteLine("[원하시는 행동을 입력해 주세요.]\n");
            Console.WriteLine("[1. 상태보기]");
            Console.WriteLine("[2. 인벤토리]");
            Console.WriteLine("[3. 상점]");


            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("상태 보기");
                    Player player = new Player(Name);
                    player.DisplayStatus();
                    break;
                case "2":
                    Console.WriteLine("인벤토리");
                    Inventory inventory = new Inventory();
                    inventory.DisplayItems();
                    break;
                case "3":
                    Console.WriteLine("상점");
                    Shop shop = new Shop();
                    shop.DisplayShop();
                    break;
                default:
                    Console.WriteLine("던전");
                    break;
            }

        }
    }

    internal class Player // 상태 클래스
    {
        public string PlayerName { get; set; }
        public int PlayerLevel { get; set; }
        public int PlayerHealth { get; set; }
        public int PlayerMana { get; set; }
        public int PlayerGold { get; set; }
        public Player(string name)
        {
            PlayerName = name;
            PlayerLevel = 1;
            PlayerHealth = 100;
            PlayerMana = 50;
            PlayerGold = 0;
        }
        public void DisplayStatus()
        {
            Console.WriteLine($"이름: {PlayerName}, 레벨: {PlayerLevel}, 체력: {PlayerHealth}, 마나: {PlayerMana}, 골드: {PlayerGold}");
        }
    }

    internal class Shop // 상점 클래스
    {
        public void DisplayShop()
        {
            Console.WriteLine("상점에 오신 것을 환영합니다!");
            Console.WriteLine("");


            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("1. 철검 - 100 골드");
                    break;
                case "2":
                    Console.WriteLine("2. 방패 - 150 골드");
                    break;
                case "3":
                    Console.WriteLine("3. 귀족의 투구 - 500 골드");
                    break;
                case "4":
                    Console.WriteLine("4. 나무몽둥이 - 50 골드");
                    break;
                case "5":
                    Console.WriteLine("0. 나가기");
                    break;
                default:
                    Console.WriteLine("던전");
                    break;
            }
        }

    }


    internal class Inventory // 인벤토리 클래스
                             // 배열을 사용하여 특정 아이템을 저장하고, DisplayItems 메서드를 통해 인벤토리 내용을 출력합니다.
    {

        public void DisplayItems()
        {
            Console.WriteLine("인벤토리에는 다음과 같은 아이템이 있습니다:");
            Console.WriteLine("1. 체력 물약");
            Console.WriteLine("2. 마나 물약");
            Console.WriteLine("3. 무기");
            Console.WriteLine("4. 방어구");
            Console.WriteLine("5. 나가기");
        }
    }






}

