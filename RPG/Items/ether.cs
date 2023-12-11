public class Ether : Item
{
    public Ether(string name = "Ether")
    {
        _name = name;
        _description = "A small crystal shard that is filled with potential energy. Use it to restore 5 motivation. ";
        _price = 5;
    }

    public override void Use(Hero target)
    {
        Motivate(target, 5);
        Console.WriteLine($"{target.GetName()} regained 5 motivation! ");
    }
}