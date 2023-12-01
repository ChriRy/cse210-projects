public class Boredom : Enemy
{
    public Boredom(string name)
    {
        _name = name;
        _type = "Distraction";
        // Potion potion = new Potion();
        // _lootList.Add(potion);
        _health = 15;
        _maxHealth = 15;
        _strength = 10;
        _defense = 10;
        _luck = 0;
        _basicAttack = 15;
        _status = "normal";
        _expDrop = 5;
        _goldDrop = 2;
    }
}