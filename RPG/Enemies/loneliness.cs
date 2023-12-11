public class Loneliness : Enemy
{
    public Loneliness(string name = "Loneliness")
    {
        _name = name;
        _type = "Depression";
        _health = 30;
        _maxHealth = 30;
        _strength = 12;
        _defense = 1;
        _luck = 25;
        _basicAttack = 7;
        _status = "normal";
        _expDrop = 12;
        _goldDrop = 5;
        List<Item> drops = new List<Item>() { new Mtndew { }, new Ether { } };
        _lootList.AddRange(drops);
    }

    public override void BasicAttack(Contender target)
    {
        base.BasicAttack(target);
        int i = GetRandom(_luck);
        int j = GetRandom(100);
        if (j <= i)
        {
            Console.WriteLine("Target is now \u001b[36mself-critical\u001b[0m!");
            target.UpdateStatus("self-critical");
        }
    }
}