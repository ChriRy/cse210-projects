public class Medication : Hero
{
    public Medication(string name)
    {
        _name = name;
        _health = 25;
        _strength = 100;
        _defense = 10;
        _luck = 5;
        _motivation = 5;
        _basicAttack = 10;
        _exp = 0;
        _level = 1;
        _resistance = "ADHD";
        _class = "Medication";
    }

    public void DailyDose(string target)
    {
        if (_motivation >= 3)
        {
            Console.WriteLine("Steven used 3 motivation to cast Daily Dose!");
            Console.WriteLine($"{target} was hit by a wave of responsibility and pills! ");
            Console.WriteLine($"{target} is now stunned!");
            _motivation -= 3;
        }
        else
        {
            Console.WriteLine("Not enough motivation to cast!");
        }
    }

}
