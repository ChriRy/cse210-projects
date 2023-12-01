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
        _inventory.Add(item);
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
    public void DisplayInventory()
    {
        foreach (Item item in _inventory)
        {
            item.GetName();
        }
    }

    public List<Hero> GetHeroes()
    {
        return _party;
    }
}