public class Goal
{
    protected string _name;
    protected string _description;
    protected string _type;
    protected int _difficulty;
    protected int _hp;
    protected bool _defeat;

    // List<string> _sprite = new List<string>();

    public Goal(string name, string description, int difficulty, bool defeat = false)
    {
        _name = name;
        _description = description;
        _type = "Simple";
        _difficulty = difficulty;
        _hp = 1;
        _defeat = defeat;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetHP()
    {
        return _hp;
    }

    public void TakeDamage()
    {
        _hp -= 1;
    }
    public bool DefeatCheck()
    {
        return _defeat;
    }

    public virtual string Stringify()
    {
        string data = $"Goal:{_type}|{_name}|{_description}|{_difficulty}|{_hp}|{_defeat}";
        return data;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Goal: {_name}");
        Console.WriteLine($"Type: {_type}");
        Console.WriteLine($"Difficulty: {_difficulty}");
        Console.WriteLine($"Description: {_description}");
        Console.WriteLine($"HP: {_hp}");
        if (_defeat)
        {
            Console.WriteLine("Defeated: Yes");
        }
        else
        {
            Console.WriteLine("Defeated: No");
        }
    }

    public void Attack(User user)
    {
        Random i = new Random();
        int attack = i.Next(1, 5);
        Console.WriteLine("The monster attacks! Choose a number between 1 and 5 to defend yourself!");
        int defense = Convert.ToInt16(Console.ReadLine());

        if (defense == attack || defense == attack + 1 || defense == attack - 1)
        {
            Console.WriteLine("You successfully blocked the attack.");
        }
        else
        {
            int damage = _difficulty * 3;
            Console.WriteLine($"The monster broke through your defense! You lose {damage} EXP!");
            user.TakeDamage(damage);
        }

    }

    public virtual void Defeat(User user)
    {
        int exp = _difficulty * 10;
        Console.WriteLine("You defeated the monster!");
        Console.WriteLine($"You gained {exp} EXP!");
        user.AddExp(exp);
        _defeat = true;
    }
}