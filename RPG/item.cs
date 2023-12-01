using System.Reflection.Metadata;

public abstract class Item
{
    protected string? _name;
    protected string? _description;
    protected int _price;

    public void Heal(Hero target, int health)
    {
        target.Heal(health);
    }

    public void ResetStatus(Hero target)
    {
        target.UpdateStatus("normal");
    }

    public int GetPrice()
    {
        return _price;
    }

    public void GetName()
    {
        Console.WriteLine($"{_name}");
    }
}