public class Team
{
    List<Hero> _party = new List<Hero>();
    List<Item> _inventory = new List<Item>();
    int _gold;

    public Team(Hero hero)
    {
        _gold = 0;
        _party.Add(hero);
    }

    public void AddPartyMember(Hero hero)
    {
        _party.Add(hero);
    }

    public void AddItem(Item item)
    {
        int storage = _inventory.Count;
        if (storage < 12)
        {
            _inventory.Add(item);
        }
        else
        {
            Console.WriteLine("Inventory is full! ");
        }
    }

    public void AddItems(List<Item> itemList)
    {
        foreach (Item item in itemList)
        {
            int storage = _inventory.Count;
            if (storage < 12)
            {
                _inventory.Add(item);
            }
            else
            {
                Console.WriteLine("Inventory is full!");
                break;
            }
        }
    }

    public void AddGold(int gold)
    {
        _gold += gold;
    }

    public void AddExp(int exp)
    {
        foreach (Hero hero in _party)
        {
            hero.AddEXP(exp);
        }
    }

    public int BattleInventory()
    {
        int i = 1;
        foreach (Item item in _inventory)
        {
            Console.WriteLine($"[{i}]. {item.GetName()}");
            i++;
        }
        Console.WriteLine();
        Console.WriteLine("Press [0] to return");
        return _inventory.Count;
    }

    public List<Item> GetInventory()
    {
        return _inventory;
    }

    public Item GetItem(int i)
    {
        Item item = _inventory[i - 1];
        _inventory.RemoveAt(i - 1);
        return item;
    }

    public void RemoveItem(int i)
    {
        _inventory.RemoveAt(i - 1);
    }

    public List<Hero> GetHeroes()
    {
        return _party;
    }

    public int CheckGold()
    {
        return _gold;
    }

    public void SpendGold(int price)
    {
        _gold -= price;
    }
}