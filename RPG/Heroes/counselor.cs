using System.Reflection;

public class Counselor : Hero
{
    public Counselor(string name)
    {
        _name = name;
        _health = 30;
        _maxHealth = 30;
        _strength = 8;
        _defense = 15;
        _luck = 5;
        _motivation = 5;
        _maxMP = 5;
        _basicAttack = 10;
        _exp = 0;
        _level = 1;
        _class = "Counselor";
        List<string> moves = new List<string>()
        {
            "Unlocked|Confrontation|3|Deals 10 damage to a single enemy and heals 5 HP",
            "Unlocked|Overshare|2|Deals 3 damage and stuns enemies",
            "Locked|Special 3|0|Filler Text",
            "Locked|Special 4|0|Filler Text",
            "Locked|Special 5|0|Filler Text",
            "Locked|Special 6|0|Filler Text"
        };
        _specialMoves.AddRange(moves);
    }

    public void Special1(Enemy enemy)
    {
        Console.WriteLine($"{GetName()} used Confrontation and confronted a problem! ");
        Console.WriteLine($"{GetName()} regained 5 HP! ");
        enemy.TakeDamage(12);
        Heal(5);
        _motivation -= 3;
    }

    public void Special2(List<Enemy> enemies)
    {
        Console.WriteLine($"{GetName()} used Overshare! ");
        Console.WriteLine($"{GetName()} whispered something disturbing and overly personal to the enemies. ");
        foreach (Enemy enemy in enemies)
        {
            enemy.UpdateStatus("stunned");
            enemy.TakeDamage(3);
        }
        Console.WriteLine("All enemies are now \u001b[33mstunned\u001b[0m! ");
        _motivation -= 2;
    }
    public void Special3() { }

    public void Special4() { }

    public void Special5() { }

    public void Special6() { }
}