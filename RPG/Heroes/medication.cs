using System.Reflection;

public class Medication : Hero
{
    public Medication(string name)
    {
        _name = name;
        _health = 25;
        _maxHealth = 25;
        _strength = 12;
        _defense = 10;
        _luck = 5;
        _motivation = 5;
        _maxMP = 5;
        _basicAttack = 10;
        _exp = 0;
        _level = 1;
        _class = "Medication";
        List<string> moves = new List<string>()
        {
            "Unlocked|Daily Dose|3|Deals 5 damage to all enemies",
            "Locked|Special 2|0|Filler Text",
            "Locked|Special 3|0|Filler Text",
            "Locked|Special 4|0|Filler Text",
            "Locked|Special 5|0|Filler Text",
            "Locked|Special 6|0|Filler Text"
        };
        _specialMoves.AddRange(moves);
    }

    public void Special1(List<Enemy> enemies)
    {
        Console.WriteLine($"{_name} used 3 motivation to cast Daily Dose!");
        Console.WriteLine($"{_name} unleashed a wave of responsibility and pills! ");
        foreach (Enemy target in enemies)
        {
            target.TakeDamage(5);
        }
        _motivation -= 3;
    }

    public void Special2(Enemy enemy)
    {
        Console.WriteLine($"{_name} used thunderbolt");
    }

    public void Special3() { }

    public void Special4() { }

    public void Special5() { }

    public void Special6() { }

}
