public class Redbull : Item
{
    public Redbull(string name = "Redbull")
    {
        _name = name;
        _description = "Gives you wiiiiiiiiings. Also strengthens your attack for one turn";
        _price = 10;
    }

    public override void Use(Hero hero)
    {
        Console.WriteLine($"{hero.GetName()} chugged a red bull. ");
        Console.WriteLine($"The redbull slogan echoes from the distance, giving {hero.GetName()} wiiiiings.");
        Console.WriteLine($"{hero.GetName()}'s attack is strengthened for the next turn! ");
        hero.AddAttackModifier(10);
    }
}