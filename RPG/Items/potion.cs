public class Potion : Item
{
    public Potion(string name = "Potion")
    {
        _name = name;
        _description = "A bottle of strange liquid that heals 10 HP. You don't know what it is, but it's probably safe. Right?";
        _price = 5;
    }

    public override void Use(Hero target)
    {
        Heal(target, 10);
        Console.WriteLine($"{target.GetName()} gained 10 HP! ");
    }
}
