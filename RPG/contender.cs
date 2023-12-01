using System.Diagnostics.CodeAnalysis;

public abstract class Contender
{
    protected string _name;
    protected int _health;
    protected int _maxHealth;
    protected int _basicAttack;
    protected int _strength;
    protected int _defense;
    protected int _luck;
    protected string _status = "normal";

    public void UpdateStatus(string status)
    {
        _status = status;
    }

    // public string StatusCheck();

    public virtual void TakeDamage(int damage)
    {
        double defense = (double)_defense / 100;
        double block = Math.Ceiling(defense * (double)_defense);
        int carryover = damage - (int)block;
        _health -= carryover;
    }

    public void BasicAttack(Contender target)
    {
        double strength = (double)_strength / 100;
        double boost = Math.Ceiling(strength * (double)_basicAttack);
        int damage = _basicAttack + (int)boost;
        target.TakeDamage(damage);
        Console.WriteLine($"The target took {damage} damage! ");
    }

    public string GetName()
    {
        return _name;
    }

    public int GetHealth()
    {
        if (_health > 0)
        {
            return _health;
        }
        else
        {
            return 0;
        }
    }

}