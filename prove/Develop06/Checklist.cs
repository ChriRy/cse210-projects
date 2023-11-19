public class Checklist : Goal
{
    public Checklist(int hp, string name, string description, int difficulty, bool defeat = false) : base(name, description, difficulty, defeat)
    {
        _name = name;
        _description = description;
        _type = "Checklist";
        _difficulty = difficulty;
        _hp = hp;
        _defeat = defeat;
    }

}