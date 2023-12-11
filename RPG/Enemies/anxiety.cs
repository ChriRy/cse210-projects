public class Anxiety : Enemy
{
    public Anxiety(string name = "Anxiety")
    {
        _name = name;
        _type = "Anxiety";
        _health = 20;
        _maxHealth = 20;
        _strength = 7;
        _defense = 5;
        _luck = 15;
        _basicAttack = 7;
        _status = "normal";
        _expDrop = 8;
        _goldDrop = 3;
        List<Item> drops = new List<Item>(){new Mtndew{}, new Mtndew{}};
        _lootList.AddRange(drops);
    }

    public override void BasicAttack(Contender target)
    {
        base.BasicAttack(target);
        int i = GetRandom(_luck);
        int j = GetRandom(100);
        if (j <= i)
        {
            Console.WriteLine("Target is now \u001b[33mstunned\u001b[0m! ");
            target.UpdateStatus("stunned");
        }
    }
}