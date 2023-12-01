public abstract class Enemy : Contender
{
    protected string? _type;
    protected int _expDrop;
    protected int _goldDrop;
    // protected List<Item> _lootList = new List<Item>();
    // add enemies dropping loot later

    public void ShowStats()
    {
        Console.WriteLine($"Enemy: {_name}");
        Console.WriteLine($"Type: {_type}");
        Console.WriteLine($"Health: {_health}");
        Console.WriteLine($"Strength: {_strength} Defense: {_defense} Luck: {_luck}");
    }

    public (int, int) DropLoot()
    {
        Random i = new Random();
        // int loot = i.Next(0, _lootList.Count);
        return (_expDrop, _goldDrop);
    }
}
