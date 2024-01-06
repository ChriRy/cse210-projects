using System.Diagnostics.CodeAnalysis;

public abstract class Contender
{
    protected string _name = "Blank"!;
    protected int _health;
    protected int _maxHealth;
    protected int _basicAttack;
    protected int _strength;
    protected int _defense;
    protected int _luck;
    protected string _status = "normal";
    protected int _damageModifier;
    protected int _attackModifier;
    protected string _color = "32";

    public void UpdateStatus(string status)
    {
        _status = status;
    }

    public string GetStatus()
    {
        return _status;
    }

    public virtual void TakeDamage(int damage)
    {
        double defense = (double)_defense / 100;
        double block = Math.Ceiling(defense * (double)_defense);
        int carryover = damage - (int)block + _damageModifier;
        _health -= carryover;
        if (_status == "self-critical")
        {
            Console.WriteLine($"{_name} is feeling \u001b[36mself critical\u001b[0m! They take extra damage");
            _status = "normal";
        }
        _damageModifier = 0;
    }

    public virtual void BasicAttack(Contender target)
    {
        double strength = (double)_strength / 100;
        double boost = Math.Ceiling(strength * (double)_basicAttack);
        int damage = _basicAttack + (int)boost + _attackModifier;
        target.TakeDamage(damage);
        Console.WriteLine($"The target took {damage} damage! ");
        _attackModifier = 0;
    }

    public virtual string GetName()
    {
        return _name;
    }

    public string BaseName()
    {
        return _name;
    }

    public int GetHealth(bool max = false)
    {
        if (_health > 0)
        {
            return _health;
        }
        else if (max)
        {
            return _maxHealth;
        }
        else
        {
            return 0;
        }
    }

    // modifiers can be positive or negative depending on the context
    public void AddDamageModifier(int i)
    {
        _damageModifier = i;
    }

    public void AddAttackModifier(int i)
    {
        _attackModifier = i;
    }

    public int GetRandom(int max)
    {
        Random i = new Random();
        int j = i.Next(0, max);
        return j;
    }
}