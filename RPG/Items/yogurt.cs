public class Yogurt : Item
{
    public Yogurt(string name = "Yogurt")
    {
        _name = name;
        _description = "Delicious fruity almost drink. Rumored to cure depression, and here it does! Also heals 15 HP. ";
        _price = 12;
    }

    public override void Use(Hero hero)
    {
        Console.WriteLine($"{hero.GetName()} decided to eat yogurt during the heat of battle. ");
        Console.WriteLine($"Depression is cured and 15 HP is restored! ");
        hero.Heal(15);
        if (hero.GetStatus() == "depressed")
        {
            hero.UpdateStatus("normal");
        }
    }
}