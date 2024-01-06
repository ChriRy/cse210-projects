public class Shop
{
    Team _party;
    List<Item> _stock = new List<Item>()
    {
        new Potion(),
        new Ether(),
        new Mtndew(),
        new Snickers(),
        new Redbull(),
        new SpriteCranberry(),
        new Yogurt(),
    };


    public Shop(Team party)
    {
        _party = party;
        Shopping();
    }

    // public void Logo()
    // {
    //     string line1 = "          000000      00     00      \u001b[35m000   000\u001b[0m      000000             ";
    //     string line2 = "         00    00     00     00     \u001b[35m00000 00000\u001b[0m     00    00          ";
    //     string line3 = "  ^      00    00     00     00    \u001b[35m0000000000000\u001b[0m    00      0      ^  ";
    //     string line4 = " / \\      00          00     00    \u001b[35m0000000000000\u001b[0m    00     00     / \\ ";
    //     string line5 = "< \u001b[33m*\u001b[0m >      0000       000000000     \u001b[35m00000000000\u001b[0m     0000000      < \u001b[33m*\u001b[0m >";
    //     string line6 = " \\ /          00      00     00      \u001b[35m000000000\u001b[0m      00            \\ / ";
    //     string line7 = "  v      00     00    00     00       \u001b[35m0000000\u001b[0m       00             v ";
    //     string line8 = "         00     00    00     00        \u001b[35m00000\u001b[0m        00                ";
    //     string line9 = "           000000     00     00          \u001b[35m0\u001b[0m          00                \n";
    //     List<string> logo = new List<string>() { line1, line2, line3, line4, line5, line6, line7, line8, line9 };

    //     foreach (string line in logo)
    //     {
    //         Console.WriteLine(line);
    //     }

    //     string greeting = "Press enter... ";
    //     Console.WriteLine(greeting.PadRight(15));
    //     Console.ReadLine();
    //     Console.Clear();
    // }
    public void Shopping()
    {
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("<>--<>--<>--<>--<>--<>--<>--<>--<>");
            Console.WriteLine("Welcome to the shop! \n");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("[1]. Buy ");
            Console.WriteLine("[2]. Sell");
            Console.WriteLine("[3]. Exit \n");
            Console.Write("> ");
            string input = Console.ReadLine()!;
            switch (input)
            {
                case "1":
                    Buy();
                    break;
                case "2":
                    Sell();
                    break;
                case "3":
                    Console.WriteLine("Thanks for stopping by! ");
                    loop = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    ResetScreen();
                    break;
            }
        }
    }

    public void Buy()
    {
        bool loop = true;
        while (loop)
        {
            Console.Clear();
            Console.WriteLine($"Current Gold: {_party.CheckGold()}");
            Console.WriteLine("<>--<>--<>--<>--<>--<>--<>--<>--<>");
            Console.WriteLine("\nWhat would you like to buy? \n");
            Display(_stock);
            Console.WriteLine("\nPress 0 to return \n");
            Console.Write("> ");
            string input = Console.ReadLine()!;

            if (input == "0")
            {
                loop = false;
                Console.Clear();
            }
            else if (int.TryParse(input, out int result) && result > 0 && result <= _stock.Count)
            {
                Item item = _stock[result - 1];
                Console.WriteLine($"Item: {item.GetName()}");
                Console.WriteLine($"Price: {item.GetPrice()}");
                Console.WriteLine($"{item.GetDescription()}\n");
                Console.WriteLine("Buy it? (y/n) ");
                string answer = Console.ReadLine()!;
                Console.WriteLine();
                if (_party.CheckGold() >= item.GetPrice() && answer == "y")
                {
                    Console.WriteLine($"You bought one {item.GetName()}. ");
                    _party.AddItem(item);
                    _party.SpendGold(item.GetPrice());
                    Console.WriteLine($"You have {_party.CheckGold()} gold left. ");
                    Wait();
                }
                else if (answer == "n")
                { }
                else if (_party.CheckGold() < item.GetPrice())
                {
                    Console.WriteLine("Sorry, you don't have enough gold. ");
                    Wait();
                }
                else
                {
                    Console.WriteLine("Invalid input. ");
                    Wait();
                }
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Invalid input. ");
                Wait();
            }
        }
    }

    public void Sell()
    {
        bool loop;
        bool loop1 = true;
        while (loop1)
        {
            if (_party.GetInventory().Count != 0)
            {
                loop = true;
            }
            else
            {
                Console.WriteLine("It doesn't look like you have any items to sell... ");
                Wait();
                loop = false;
                loop1 = false;
                Console.Clear();
            }

            while (loop)
            {
                Console.Clear();
                Console.WriteLine($"Current Gold: {_party.CheckGold()}");
                Console.WriteLine("<>--<>--<>--<>--<>--<>--<>--<>--<>");
                Console.WriteLine("\nWhat would you like to sell? \n");
                Display(_party.GetInventory());
                Console.WriteLine("\nPress 0 to return \n");
                Console.Write("> ");
                string input = Console.ReadLine()!;

                if (input == "0")
                {
                    loop = false;
                    loop1 = false;
                    Console.Clear();
                }
                else if (int.TryParse(input, out int result) && result > 0 && result <= _party.GetInventory().Count)
                {
                    Item item = _party.GetInventory()[result - 1];
                    Console.WriteLine($"Item: {item.GetName()}");
                    Console.WriteLine($"Selling Price: {item.GetPrice() - 2}");
                    Console.WriteLine($"{item.GetDescription()}\n");
                    Console.WriteLine("Sell it? (y/n) ");
                    string answer = Console.ReadLine()!;
                    Console.WriteLine();
                    if (answer == "y")
                    {
                        Console.WriteLine($"You sold one {item.GetName()}. ");
                        _party.RemoveItem(result);
                        _party.AddGold(item.GetPrice() - 2);
                        Console.WriteLine($"You now have {_party.CheckGold()} gold. ");
                        Wait();
                    }
                    else if (answer == "n")
                    { }
                    else
                    {
                        Console.WriteLine("Invalid input. ");
                        Wait();
                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid input. ");
                    Wait();
                }
                loop = false;
            }
        }
    }

    public void Display(List<Item> itemList)
    {
        int length = itemList.Count;
        int counter = 1;

        for (int i = 0; i < length; i += 2)
        {
            string item1 = itemList[i].GetName()!.PadRight(20);
            string item2 = (i + 1 < length) ? itemList[i + 1].GetName()!.PadLeft(20) : "<------>".PadLeft(20);

            string display = $"[{counter}] - {item1} <-||-> {item2} - [{counter + 1}]";


            Console.WriteLine($"{display}");
            counter += 2;
        }
    }

    public void Wait()
    {
        Console.WriteLine("Press enter to continue... ");
        Console.ReadLine();
    }
    public void ResetScreen()
    {
        Console.WriteLine("Press enter to continue... ");
        Console.ReadLine();
        Console.Clear();
    }
}