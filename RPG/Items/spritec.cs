public class SpriteCranberry : Item
{
    public SpriteCranberry(string name = "Sprite Cranberry")
    {
        _name = name;
        _description = "Want a Sprite Cranberry? Heals 10 HP and cures burning";
        _price = 7;
    }

    public override void Use(Hero hero)
    {
        Console.WriteLine($"Lebron James appears in the distance and throws {hero.GetName()} a Sprite Cranberry. ");
        Console.WriteLine($"It's no longer the thirstiest time of the year for {hero.GetName()}! ");
        Console.WriteLine($"{hero.GetName()} gained 10 HP and is feeling cool and refreshed. ");
        hero.Heal(10);
        if (hero.GetStatus() == "burned")
        {
            hero.UpdateStatus("normal");
        }
    }
}