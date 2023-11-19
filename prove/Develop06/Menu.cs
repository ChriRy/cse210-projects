public class Menu
{
    User _user;
    Savefile _savefile;
    public Menu(User user = null)
    {

    }

    public void TitleScreen()
    {
        Console.WriteLine("Welcome to Corona Quest! \n");
    }

    public void ChooseProfile()
    {
        Savefile file1 = new Savefile("file1.txt", "Ryan");
        Savefile file2 = new Savefile("file2.txt");
        Savefile file3 = new Savefile("file3.txt");

        file1.DisplayFile(1);
        file2.DisplayFile(2);
        file3.DisplayFile(3);

        Console.WriteLine();
        Console.Write("Select a profile: ");
        int profile = Convert.ToInt16(Console.ReadLine());

        switch (profile)
        {
            case 1:
                _savefile = file1;
                _user = Intro(file1);
                break;
            case 2:
                _savefile = file2;
                _user = Intro(file2);
                break;
            case 3:
                _savefile = file3;
                _user = Intro(file3);
                break;
            default:
                Console.WriteLine("Invalid input. Please restart program. ");
                Environment.Exit(0);
                break;
        }


    }

    public User Intro(Savefile file)
    {
        if (File.Exists(file.GetFilename()))
        {
            Console.WriteLine("Welcome back! Good luck slaying your demons today. ");
            Clear();
            return file.Load();
        }
        else
        {
            Console.WriteLine("[INTRO FILLER TEXT]");
            Console.WriteLine("What is your name? ");
            string name = Console.ReadLine();
            User start = new User(name);
            file.Save(start);
            return file.Load();
        }
    }

    public void MainMenu()
    {
        bool loop = true;

        while (loop)
        {
            Console.WriteLine("\nSelect one of the options: \n");
            Console.WriteLine("1. Fight (Record event)");
            Console.WriteLine("2. Summon (Create new goal)");
            Console.WriteLine("3. Monster Guide (View current and past goals)");
            Console.WriteLine("4. Journal (View personal stats)");
            Console.WriteLine("5. Save and Quit");
            Console.Write("> ");
            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    Fight();
                    break;
                case "2":
                    Summon();
                    break;
                case "3":
                    Monsters();
                    break;
                case "4":
                    Journal();
                    break;
                case "5":
                    _savefile.Save(_user);
                    loop = false;
                    break;
            }
        }
    }

    public Goal Select(bool limit)
    {
        Console.WriteLine("These are your current goals: ");
        List<Goal> goallist = _user.GetGoals();
        int max;

        if (goallist.Count >= 6 && limit)
        {
            max = 6;
        }
        else
        {
            max = goallist.Count;
        }

        List<Goal> currentList = new List<Goal>();
        int n = 1;
        for (int i = 0; i < max; i++)
        {
            Goal goal = goallist[i];
            bool status = goal.DefeatCheck();
            if (status == false)
            {
                string name = goal.GetName();
                Console.WriteLine($"{n}. {name}");
                currentList.Add(goal);
                n++;
            }
        }

        Console.Write("Select a goal: ");
        int input = Convert.ToInt16(Console.ReadLine()) - 1;

        if (input <= 6)
        {
            Goal selection = currentList[input];
            return selection;
        }
        else
        {
            Console.WriteLine("Invalid entry. Please restart program. ");
            Environment.Exit(0);
        }

        //this is just to make the error go away
        return currentList[0];
    }

    public void Fight()
    {
        Goal goal = Select(true);

        Console.WriteLine("Your goal appears!! \n");
        goal.DisplayInfo();

        Console.WriteLine("\nWhat do you do?");
        Console.WriteLine("1. Attack (Input progress)");
        Console.WriteLine("2. Run (Return to menu)");

        Console.Write("> ");
        int input = Convert.ToInt16(Console.ReadLine());

        if (input == 1)
        {
            Console.WriteLine("You attack the monster with productivity! ");
            Console.WriteLine("The monster took 1 damage. ");
            Clear();

            goal.TakeDamage();
            int hp = goal.GetHP();
            if (hp == 0)
            {
                goal.Defeat(_user);
            }
            else
            {
                Console.WriteLine("The monster is angered!");
                goal.Attack(_user);
                Console.WriteLine("The monster backs away, then fades into the darkness... ");
                Console.WriteLine("You relax and start to decide your next move.");
            }
        }
        else
        {
            Console.WriteLine("You decide to flee and live to fight another day.");
        }
        Clear();
    }

    public void Summon()
    {
        Console.WriteLine("You decide to summon a new monster to test your strength. ");

        Console.WriteLine("1. Simple (A goal you do once)");
        Console.WriteLine("2. Checklist (A goal that has multiple steps or reps)");
        Console.WriteLine("3. Eternal (A daily or weekly goal that repeats always)\n");
        Console.WriteLine("What kind do you summon? ");
        string type = Console.ReadLine();

        Console.Write("Enter a name for the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter a short description: ");
        string description = Console.ReadLine();
        Console.Write("How difficult is the goal (1-10)? ");
        int difficulty = Convert.ToInt16(Console.ReadLine());

        switch (type)
        {
            case "1":
                Goal newGoal = new Goal(name, description, difficulty);
                _user.AddGoal(newGoal);
                Console.WriteLine("You've successfully summoned a simple type monster!");
                break;
            case "2":
                Console.Write("How many repetitions do you want? ");
                int hp = Convert.ToInt16(Console.ReadLine());
                Checklist newChecklist = new Checklist(hp, name, description, difficulty);
                _user.AddGoal(newChecklist);
                Console.WriteLine("You've successfully summoned a checklist type monster!");
                break;
            case "3":
                Eternal newEternal = new Eternal(name, description, difficulty);
                _user.AddGoal(newEternal);
                Console.WriteLine("You've successfully summoned an eternal type monster!");
                break;
            default:
                Console.WriteLine("You try to summon something, but nothing happens.");
                Console.WriteLine("You suspect that you may have done something wrong...");
                break;
        }
        _savefile.Save(_user, "The monster runs off, but you know you'll meet again. ");

        Clear();
    }

    public void Monsters()
    {
        Console.WriteLine("This is the record of all of the monsters you've fought. Look back at all the progress you've made! \n");

        List<Goal> goallist = _user.GetGoals();
        int max = goallist.Count;

        int n = 2;
        for (int i = 0; i < max; i++)
        {
            Goal goal = goallist[i];
            Console.WriteLine("-------------------------------------");
            goal.DisplayInfo();
            if (i == n)
            {
                n += 3;
                Clear();
            }
        }
        Clear();
    }


    public void Journal()
    {
        Console.WriteLine("This is where you can see your personal progress. Level up as much as you can! \n");
        _user.Stats();
        Clear();
    }
    public void Clear()
    {
        Console.WriteLine("Press enter to continue... ");
        Console.ReadLine();
        Console.Clear();
    }
}
