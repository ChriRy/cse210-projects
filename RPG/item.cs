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

    public void Motivate(Hero target, int motivation)
    {
        target.Motivate(motivation);
    }

    public void ResetStatus(Hero target)
    {
        target.UpdateStatus("normal");
    }

    public int GetPrice()
    {
        return _price;
    }

    public string? GetName()
    {
        return _name;
    }

    public string? GetDescription()
    {
        return _description;
    }

    public virtual void Use(Hero hero) { }
}