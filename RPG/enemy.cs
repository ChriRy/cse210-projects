public abstract class Enemy : Contender
{
    protected string? _type;
    protected int _expDrop;
    protected int _goldDrop;
    new protected int _color = 35;
    protected List<Item> _lootList = new List<Item>();
    // add enemies dropping loot later

    public override string GetName()
    {
        return $"\u001b[{_color}m{_name}\u001b[0m";
    }
    public void ShowStats()
    {
        Console.WriteLine($"Enemy: {_name}");
        Console.WriteLine($"Type: {_type}");
        Console.WriteLine($"Health: {_health}");
        Console.WriteLine($"Strength: {_strength} Defense: {_defense} Luck: {_luck}");
    }

    public (int, int, bool) DropLoot()
    {
        bool odds;
        Random i = new Random();
        int odds1 = i.Next(0, _luck);
        int odds2 = i.Next(0, _luck);
        if (odds1 == odds2)
        {
            odds = true;
        }
        else
        {
            odds = false;
        }
        return (_expDrop, _goldDrop, odds);
    }

    public Item DropItem()
    {
        Random i = new Random();
        int j = i.Next(0, _lootList.Count);
        return _lootList[j];
    }
}
