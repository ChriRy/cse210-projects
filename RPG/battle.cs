using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Formatters;
using Microsoft.VisualBasic;

public class Battle
{
    Team _party;
    List<Hero> _heroes;
    List<Enemy> _enemies;
    List<Contender> _contenders = new List<Contender>();
    int _turn;

    public Battle(Team party, List<Enemy> enemies)
    {
        _party = party;
        _heroes = _party.GetHeroes();
        _enemies = enemies;
        _turn = 0;
        _contenders.AddRange(_heroes);
        _contenders.AddRange(enemies);
    }

    public void EnemyCount()
    {
        Console.WriteLine($"{_enemies.Count} enemies");
    }
    // max three enemies
    public void BattleLoop()
    {
        List<Enemy> Edefeated = new List<Enemy>();
        List<Hero> Hdefeated = new List<Hero>();
        bool loop = true;
        while (loop)
        {
            //ShowBattlefield shows the current battlefield
            ShowBattlefield();
            Contender currentTurn = _contenders[_turn];

            // checks the status of the current turn and decides accordingly
            bool turn = StatusCheck(currentTurn);

            if (turn)
            {
                // Checks whether enemy or hero turn and if they are still alive
                if (currentTurn is Hero && currentTurn.GetHealth() > 0)
                {
                    ShowMenu((Hero)currentTurn);
                }
                else if (currentTurn is Enemy && currentTurn.GetHealth() > 0)
                {
                    // makes sure that an enemy attacks someone that's still alive
                    bool search = true;
                    while (search)
                    {
                        int i = GetRandom(_heroes.Count);
                        if (_heroes[i].GetHealth() > 0)
                        {
                            Console.WriteLine($"{currentTurn.GetName()} attacked {_heroes[i].GetName()}!");
                            currentTurn.BasicAttack(_heroes[i]);
                            search = false;
                        }
                    }
                    Wait();
                }
            }

            currentTurn.UpdateStatus("normal");
            // Checks whether or not anyone has been defeated and checks for end of battle
            foreach (Contender contender in _contenders)
            {
                if (contender is Enemy && contender.GetHealth() <= 0 && !Edefeated.Contains(contender))
                {
                    Edefeated.Add((Enemy)contender);
                    Console.WriteLine($"{contender.GetName()} has been defeated!");
                    Wait();
                }
                else if (contender is Hero && contender.GetHealth() <= 0 && !Hdefeated.Contains(contender))
                {
                    Hdefeated.Add((Hero)contender);
                    Console.WriteLine($"{contender.GetName()} has fallen to the monsters!");
                    Wait();
                }
            }

            // victory route if all enemies are defeated
            if (Edefeated.Count == _enemies.Count)
            {
                ResetScreen();
                Console.WriteLine("All enemies are defeated!\n");
                int expgain = 0;
                int goldgain = 0;
                foreach (Enemy enemy in _enemies)
                {
                    (int, int, bool) rewards = enemy.DropLoot();
                    _party.AddExp(rewards.Item1);
                    _party.AddGold(rewards.Item2);
                    expgain += rewards.Item1;
                    goldgain += rewards.Item2;
                    if (rewards.Item3)
                    {
                        Item drop = enemy.DropItem();
                        _party.AddItem(drop);
                        Console.WriteLine($"{enemy.GetName()} dropped {rewards.Item1} exp, {rewards.Item2} gold, and a {drop.GetName()}!");
                    }
                    else
                    {
                        Console.WriteLine($"{enemy.GetName()} dropped {rewards.Item1} exp and {rewards.Item2} gold!");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("---------------------------------------------------------\n");
                Console.WriteLine($"The party gained {expgain} exp and {goldgain} gold!\n");
                Wait();
                loop = false;
            }

            // game over route if all heroes are defeated
            if (Hdefeated.Count == _heroes.Count)
            {
                ResetScreen();
                Console.WriteLine("All the heroes have fallen to the monsters... ");
                Wait();
                loop = false;
            }

            // changes the turn and resets it when everyone has gone
            _turn++;
            if (_turn == _contenders.Count)
            {
                _turn = 0;
            }

            foreach (Contender contender in _contenders)
            {
                bool first = true;
                if (contender.GetStatus() == "burned")
                {
                    if (first)
                    {
                        ResetScreen();
                    }
                    Burn(contender);
                    Wait(true);
                }
            }

            Console.Clear();
        }
    }

    public void ShowBattlefield()
    {
        Console.WriteLine("<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>\n");
        foreach (Enemy enemy in _enemies)
        {
            ShowContender(enemy);
        }
        Console.WriteLine("\n\n");
        foreach (Hero hero in _heroes)
        {
            ShowContender(hero);
        }
        Console.WriteLine("\n");
        Console.WriteLine("<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>--<>");

    }

    public void ShowContender(Contender contender)
    {
        string name = contender.GetName();
        int health = contender.GetHealth();
        string currentTurn = _contenders[_turn].GetName();
        if (health > 0)
        {
            if (currentTurn == name)
            {
                Console.Write($"[\u001b[47m{contender.BaseName()}\u001b[0m] - [\u001b[32m{health}\u001b[0m] \t");
            }
            else if (contender is Enemy)
            {
                Console.Write($"[{name}] - [\u001b[32m{health}\u001b[0m] \t");
            }
            else if (contender is Hero)
            {
                Console.Write($"[{name}] - [\u001b[32m{health}\u001b[0m] \t");
            }
        }
        else
        {
            Console.Write($"[\u001b[31m{contender.BaseName()}\u001b[0m] - [\u001b[31m{health}\u001b[0m] \t");
        }
    }

    public void ShowMenu(Hero hero)
    {
        bool loop = true;
        while (loop)
        {
            Console.Write("[A]ttack ---- [S]pecial ---- [I]tem ---- S[t]ats ---- > ");
            string? choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "a":
                    Contender target;
                    if (_enemies.Count > 1)
                    {
                        target = SelectEnemy();
                    }
                    else
                    {
                        target = _enemies[0];
                    }

                    if (target.GetHealth() <= 0)
                    {
                        Console.WriteLine("Target is already defeated. ");
                    }
                    else
                    {
                        Console.WriteLine($"\n{hero.GetName()} attacked {target.GetName()}!");
                        hero.BasicAttack(target);
                        loop = false;
                    }
                    Wait();
                    ResetScreen();
                    break;
                case "s":
                    if (hero.GetStatus() != "depressed")
                    {
                        //select move
                        bool success = true;
                        hero.SpecialMenu();
                        Console.Write("Select Move > ");
                        string? input = Console.ReadLine();
                        Console.WriteLine();

                        switch (input)
                        {
                            case "1":
                                success = TargetCheck(hero, "Special1", 1);
                                break;
                            case "2":
                                success = TargetCheck(hero, "Special2", 2);
                                break;
                            case "3":
                                success = TargetCheck(hero, "Special3", 3);
                                break;
                            case "4":
                                success = TargetCheck(hero, "Special4", 4);
                                break;
                            case "5":
                                success = TargetCheck(hero, "Special5", 5);
                                break;
                            case "6":
                                success = TargetCheck(hero, "Special6", 6);
                                break;
                            case "0":
                                ResetScreen();
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                        // if the player successfully did a special move, do this
                        if (!success)
                        {
                            Wait();
                            loop = false;
                        }
                        // if the player put in zero to go back, do this
                        else if (input == "0")
                        {
                            ResetScreen();
                        }
                        else
                        {
                            Wait();
                            ResetScreen();
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{hero.GetName()} is \u001b[34mdepressed\u001b[0m and cannot use special moves! ");
                        Wait();
                        ResetScreen();
                        break;
                    }
                case "i":
                    int count = _party.BattleInventory();
                    Console.Write("Select item > ");
                    string? input1 = Console.ReadLine();
                    Console.WriteLine();

                    bool valid = int.TryParse(input1, out int result);

                    // runs if player selection is valid
                    if (valid && result <= count && result != 0)
                    {
                        Item selection = _party.GetItem(result);
                        selection.Use(SelectHero());
                        loop = false;
                    }
                    // runs if player inputs 0 to go back
                    else if (result == 0)
                    {
                        ResetScreen();
                    }
                    // runs if there is an error
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }

                    // this removes the pause if the player input 0 and puts the pause in for everything else
                    if (result != 0)
                    {
                        Wait();
                        ResetScreen();
                    }
                    break;
                case "t":
                    Console.WriteLine("\nCurrent Stats: ");
                    Console.WriteLine("--------------------------------------------------");
                    foreach (Hero member in _heroes)
                    {
                        member.MiniStats();
                    }
                    Console.WriteLine("--------------------------------------------------");
                    Wait();
                    ResetScreen();
                    break;
                default:
                    Console.WriteLine("Invalid input. ");
                    Wait();
                    ResetScreen();
                    break;
            }
        }
    }

    public void Wait(bool mini = false)
    {
        if (!mini)
        {
            Console.WriteLine("Press enter to continue... ");
            Console.ReadLine();
        }
        else
        {
            Console.ReadLine();
        }
    }

    public int GetRandom(int max)
    {
        Random i = new Random();
        int j = i.Next(0, max);
        return j;
    }

    public Enemy SelectEnemy()
    {
        Console.Write("Select enemy: ");
        Enemy target = _enemies[Convert.ToInt16(Console.ReadLine()) - 1];
        return target;
    }

    public Hero SelectHero()
    {
        bool loop = true;
        int selection = 0;
        while (loop)
        {
            int i = 1;
            foreach (Hero hero in _heroes)
            {
                Console.Write($"[{i}]. ");
                hero.MiniStats();
                i++;
            }
            Console.Write("\nSelect Hero > ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int result) && result <= _heroes.Count)
            {
                selection = result - 1;
                loop = false;
            }
            else
            {
                Console.WriteLine("Invalid input");
                Wait();
                ResetScreen();
            }
        }
        return _heroes[selection];
    }

    public bool TargetCheck(Hero hero, string special, int i)
    {
        if (SpecialCheck(hero, i))
        {
            Type type = hero.GetType();
            MethodInfo? method = type.GetMethod(special);
            ParameterInfo[] argument = method!.GetParameters();
            string targetType = $"{argument[0]}";
            if (targetType == "Enemy enemy")
            {
                Enemy target = SelectEnemy();
                method.Invoke(hero, new object[] { target });
            }
            else if (targetType == "Hero hero")
            {
                Hero target = SelectHero();
                method.Invoke(hero, new object[] { target });
            }
            else
            {
                method.Invoke(hero, new object[] { _enemies });
            }
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool SpecialCheck(Hero hero, int i)
    {
        int currentMP = hero.GetMotivation();
        string specialMove = hero.GetSpecialMove(i);
        string[] moveData = specialMove.Split("|");
        string lockStatus = moveData[0];
        int motivation = Convert.ToInt16(moveData[2]);
        if (lockStatus == "Unlocked" && currentMP >= motivation)
        {
            return true;
        }
        else if (lockStatus == "Unlocked" && currentMP < motivation)
        {
            Console.WriteLine("Not enough motivation! ");
            return false;
        }
        else
        {
            Console.WriteLine("Move not unlocked! ");
            return false;
        }
    }

    public void ResetScreen()
    {
        Console.Clear();
        ShowBattlefield();
    }

    public bool StatusCheck(Contender contender)
    {
        string status = contender.GetStatus();
        bool turn;
        if (contender.GetHealth() <= 0)
        {
            turn = false;
            return turn;
        }

        switch (status)
        {
            case "normal":
                turn = true;
                break;
            case "stunned":
                Console.WriteLine($"{contender.GetName()} is \u001b[33mstunned\u001b[0m and cannot attack! ");
                turn = false;
                Wait();
                break;
            //case "burned":
            //burned is handled separately because it lasts multiple turns
            //break;
            case "depressed":
                Console.WriteLine($"{contender.GetName()} is \u001b[34mdepressed\u001b[0m and has no motivation! They cannot use special attacks this turn. \n");
                turn = true;
                Wait();
                break;
            case "self-critical":
                Console.WriteLine($"{contender.GetName()} is \u001b[36mself-critical\u001b[0m! They will take more damage. \n");
                turn = true;
                Wait();
                break;
            default:
                turn = true;
                break;
        }
        ResetScreen();
        return turn;
    }

    public void Burn(Contender contender)
    {
        Console.WriteLine($"{contender.GetName()} is \u001b[31mburned\u001b[0m! They took 2 damage. \n");
        contender.TakeDamage(3);
    }
}