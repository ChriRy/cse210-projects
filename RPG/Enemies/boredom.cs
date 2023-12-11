public class Boredom : Enemy
{
    public Boredom(string name = "Boredom")
    {
        _name = name;
        _type = "Distraction";
        _health = 15;
        _maxHealth = 15;
        _strength = 5;
        _defense = 5;
        _luck = 0;
        _basicAttack = 5;
        _status = "normal";
        _expDrop = 5;
        _goldDrop = 2;
        List<Item> drops = new List<Item>(){new Ether{}, new Potion{}};
        _lootList.AddRange(drops);
    }
}