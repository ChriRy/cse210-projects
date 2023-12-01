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
        int defeated = 0;
        bool loop = true;
        while (loop)
        {
            //ShowBattlefield shows the current battlefield
            ShowBattlefield();
            Contender currentTurn = _contenders[_turn];
            Console.WriteLine($"Length: {_contenders.Count} Turn: {_turn}");

            if (currentTurn is Hero && currentTurn.GetHealth() > 0)
            {
                ShowMenu((Hero)currentTurn);
            }
            else if (currentTurn is Enemy && currentTurn.GetHealth() > 0)
            {
                int i = GetRandom(_heroes.Count);
                Console.WriteLine($"The monster attacked {_heroes[i].GetName()}!");
                currentTurn.BasicAttack(_heroes[i]);
                Wait();
            }

            foreach (Contender contender in _contenders)
            {
                int i = DeathCheck(contender);
                defeated += i;
                Console.WriteLine($"Defeated: {defeated}");
                if (defeated == _enemies.Count)
                {
                    Console.WriteLine("Victory!");
                    loop = false;
                }
            }

            _turn++;
            if (_turn == _contenders.Count)
            {
                _turn = 0;
            }

            Console.Clear();
        }

        int expgain = 0;
        int goldgain = 0;
        foreach (Enemy enemy in _enemies)
        {
            (int, int) rewards = enemy.DropLoot();
            Console.WriteLine($"{enemy.GetName()} dropped {rewards.Item1} exp and {rewards.Item2} gold!\n");
            _party.AddExp(rewards.Item1);
            _party.AddGold(rewards.Item2);
            expgain += rewards.Item1;
            goldgain += rewards.Item2;
        }
        Console.WriteLine($"The party gained {expgain} exp and {goldgain} gold!\n");
        Wait();
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
                Console.Write($"\u001b[47;30m[{name}]-[{health}]\u001b[0m\t");
            }
            else if (contender is Enemy)
            {
                Console.Write($"\u001b[35m[{name}]-[{health}]\u001b[0m\t");
            }
            else if (contender is Hero)
            {
                Console.Write($"\u001b[36m[{name}]-[{health}]\u001b[0m\t");
            }
        }
        else
        {
            Console.Write($"\u001b[31m[{name}]-[{health}]\u001b[0m\t");
        }
    }

    public void ShowMenu(Hero hero)
    {
        Console.Write("[A]ttack] ---- [S]pecial] ---- [I]tem] ---- > ");
        string? choice = Console.ReadLine();
        bool loop = true;
        while (loop)
        {
            switch (choice)
            {
                case "a":
                    if (_enemies.Count > 1)
                    {
                        Console.Write("Select enemy: ");
                        Enemy target = _enemies[Convert.ToInt16(Console.ReadLine()) - 1];
                        Console.WriteLine($"{hero.GetName()} attacked {target.GetName()}!");
                        hero.BasicAttack(target);
                        Wait();
                    }
                    else
                    {
                        Enemy target = _enemies[0];
                        Console.WriteLine($"{hero.GetName()} attacked {target.GetName()}!");
                        hero.BasicAttack(target);
                        Wait();
                    }
                    break;
                case "s":
                    break;
                case "i":
                    break;
                default:
                    Console.WriteLine("Something went wrong B");
                    break;
            }
            loop = false;
        }
    }

    public int DeathCheck(Contender contender)
    {
        if (contender.GetHealth() <= 0)
        {
            Console.WriteLine($"{contender.GetName()} was defeated!");
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public void Wait()
    {
        Console.WriteLine("Press enter to continue... ");
        Console.ReadLine();
    }

    public int GetRandom(int max)
    {
        Random i = new Random();
        int j = i.Next(0, max);
        return j;
    }

}