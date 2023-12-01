using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

public abstract class Hero : Contender
{
    protected int _motivation;
    protected int _exp;
    protected int _level;
    protected string? _resistance;
    protected string? _class;

    public void ShowStats()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Level {_level} {_class}");
        Console.WriteLine($"EXP to next level: {(75 + 25 * _level) - _exp}");
        Console.WriteLine($"Strength: {_strength}  Defense: {_defense}  Luck: {_luck}");
        Console.WriteLine($"Status: {_status}");
    }

    public void AddEXP(int exp)
    {
        _exp += exp;
        LevelUp();
    }

    public void LevelUp()
    {
        int nextLevel = 75 + (_level * 25);
        if (_exp == nextLevel)
        {
            _level += 1;
            Console.WriteLine($"{_name} is now level {_level}! ");

            // put something here about raising stats
        }
    }

    public override void TakeDamage(int damage)
    {
        double defense = (double)_defense / 100;
        double block = Math.Ceiling(defense * (double)_defense);
        int carryover = damage - (int)block;
        _health -= carryover;
    }

    public void Heal(int health)
    {
        int potential = _health + health;
        if (potential < _maxHealth)
        {
            _health = potential;
        }
        else
        {
            _health = _maxHealth;
        }
    }



}
