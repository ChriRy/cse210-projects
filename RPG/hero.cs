using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

public abstract class Hero : Contender
{
    protected int _motivation;
    protected int _maxMP;
    protected List<string> _specialMoves = new List<string>();
    protected int _exp;
    protected int _level;

    // protected string? _resistance;
    protected string? _class;
    new protected string _color = "36";

    public void ShowStats()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Level {_level} {_class}");
        Console.WriteLine($"EXP to next level: {(75 + 25 * _level) - _exp}");
        Console.WriteLine($"Strength: {_strength}  Defense: {_defense}  Luck: {_luck}");
        Console.WriteLine($"Status: {_status}");
    }

    public void MiniStats()
    {
        Console.WriteLine($"Name: {_name}  <>  Health: {_health}  <>  Motivation: {_motivation}  <> Status: {_status}");
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

    // This is here if I ever implement type resistance
    //
    // public override void TakeDamage(int damage)
    // {
    //     double defense = (double)_defense / 100;
    //     double block = Math.Ceiling(defense * (double)_defense);
    //     int carryover = damage - (int)block;
    //     _health -= carryover;
    // }

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

    public void Motivate(int MP)
    {
        _motivation += MP;
        if (_motivation > _maxMP)
        {
            _motivation = _maxMP;
        }
    }

    public void SpecialMenu()
    {
        int i = 1;
        //put if statement here, a move is either unlocked or locked. As the player levels up more moves are unlocked. 
        foreach (string move in _specialMoves)
        {
            string[] moveData = move.Split("|");
            if (moveData[0] == "Unlocked")
            {
                Console.WriteLine($"[{i}] - {moveData[1]}     Motivation: {moveData[2]}");
                Console.WriteLine($"        <> {moveData[3]}");
            }
            else
            {
                Console.WriteLine($"[{i}] - [Locked]  \n");
            }
            i++;
        }
        Console.WriteLine("Press [0] to return");
    }

    public string GetSpecialMove(int i)
    {
        return _specialMoves[i - 1];
    }

    public int GetMotivation()
    {
        return _motivation;
    }

    public override string GetName()
    {
        return $"\u001b[{_color}m{_name}\u001b[0m";
    }


}
