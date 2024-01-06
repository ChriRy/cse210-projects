public class Snickers : Item
{
    public Snickers(string name = "Snickers")
    {
        _name = name;
        _description = "You're not yourself when you're hungry. Maxes out your HP";
        _price = 10;
    }

    public override void Use(Hero hero)
    {
        int maxHealth = hero.GetHealth(true);
        Heal(hero, maxHealth);
    }
}