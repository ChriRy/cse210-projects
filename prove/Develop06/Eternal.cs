public class Eternal : Goal
{
    int _defeatCount;
        public Eternal(string name, string description, int difficulty, bool defeat = false, int defeatCount = 0) : base(name, description, difficulty, defeat)
    {
        _name = name;
        _description = description;
        _type = "Eternal";
        _difficulty = difficulty;
        _hp = 30;
        _defeat = false;
        _defeatCount = defeatCount;
    }

    public override void Defeat(User user)
    {
        int exp = _difficulty * 10;
        Console.WriteLine("You defeated the monster!");
        Console.WriteLine($"You gained {exp} EXP!");
        user.AddExp(exp);
        _defeat = true;
        Console.WriteLine("But this is only the beginning...");
        Console.WriteLine("An eternal monster must be constantly fought.");
        Console.WriteLine("Will you fight the same monster? Or will you fight something stronger? ");
        Console.WriteLine("1. Revive monster (repeat goal)");
        Console.WriteLine("2. Summon something stronger (update goal)");
        Console.Write("> ");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("You bravely set out to fight the monster again. Good luck hero!");
                break;
            case "2":
                Console.WriteLine("You seek another challenge..." );
                Update();
                Console.WriteLine("Good luck on your new quest! ");
                break;
            default:
                Console.WriteLine("You bravely set out to fight the monster again. Good luck hero!");
                break;
        }
    }

    public override string Stringify()
    {
        string data = $"Goal:{_type}|{_name}|{_description}|{_difficulty}|{_hp}|{_defeat}|{_defeatCount}";
        return data;
    }
    public void Update()
    {
        Console.WriteLine("What is the new goal? ");
        string goal = Console.ReadLine();
        Console.WriteLine("What is the new description? ");
        string description = Console.ReadLine();
        Console.WriteLine("What is the new difficulty? ");
        int difficulty = Convert.ToInt16(Console.ReadLine());

        _name = goal;
        _description = description;
        _difficulty = difficulty;
    }

}