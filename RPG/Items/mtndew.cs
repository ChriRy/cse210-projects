public class Mtndew : Item
{
    public Mtndew(string name = "Mountain Dew")
    {
        _name = name;
        _description = "Hey, they can't all be mystical items. It's just a mountain dew. The caffeine will clear your status effects.";
        _price = 6;
    }

    public override void Use(Hero target)
    {
        target.UpdateStatus("normal");
        Console.WriteLine($"{target.GetName()} chugged a Mountain Dew. All status effects are cleared! ");
    }
}