public class User
{
    string _name;
    string _rank;
    int _exp;
    int _level;
    List<Goal> _goals = new List<Goal>();

    public User(string name, string rank = "Novice", int exp = 0, int level = 1)
    {
        _name = name;
        _rank = rank;
        _exp = exp;
        _level = level;
    }

    public string Stringify()
    {
        string data = $"User:{_name}|{_rank}|{_exp}|{_level}";
        return data;
    }

    public List<Goal> GetGoals()
    {
        return _goals;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void AddExp(int exp)
    {
        _exp += exp;
        while (_exp >= _level * 100)
        {
            _level++;
            Console.WriteLine("Congratulations, you leveled up!");

            int milestone = _level % 5;
            if (milestone == 0)
            {
                string newRank = GetRank();
                _rank = newRank;
            }
            Console.WriteLine($"You are now a level {_level} {_rank}");
        }
    }

    public string GetRank()
    {
        Random random = new Random();

        string[] adjectives =
        {
            "Authoratative",
            "Big",
            "Cantankerous",
            "Deadly",
            "Experienced",
            "Flirty",
            "Gritty",
            "Heavenly",
            "Inescapable",
            "Justified",
            "Kindly",
            "Lemon-Scented",
            "Massive",
            "Northerly",
            "Opaque",
            "Practicing",
            "Questing",
            "Rallying",
            "Sneaking",
            "Tough",
            "Unnerving",
            "Virtuous",
            "Wizened",
            "Exacting",
            "Yelling",
            "Zippy"
        };

        string[] titles =
        {
            "Achiever",
            "Battler",
            "Craftsman",
            "Defender",
            "Earner",
            "Fighter",
            "Grappler",
            "Hitter",
            "Imparter",
            "Jester",
            "Killer",
            "Leader",
            "Marauder",
            "Nourisher",
            "Oracle",
            "Player",
            "Quester",
            "Rider",
            "Slayer",
            "Traveler",
            "Undertaker",
            "Vase-Breaker",
            "Wayfinder",
            "Exacter",
            "Yodeler",
            "Zealot"
        };

        int i = random.Next(0, adjectives.Length);
        int j = random.Next(0, titles.Length);
        string rank = $"{adjectives[i]} {titles[j]}";
        return rank;
    }

    public void TakeDamage(int damage)
    {
        _exp -= damage;
    }

    public void Stats()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Rank: Level {_level} {_rank}");
        Console.WriteLine($"EXP: {_exp}");
        int nextLevel = (_level * 100) - _exp;
        Console.WriteLine($"EXP till next level: {nextLevel}");
    }

}