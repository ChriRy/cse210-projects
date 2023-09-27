public class Player
{
    private string _name;
    private int _jNumber;

    public Player(string name, int jNumber)
    {
        _name = name;
        _jNumber = jNumber;
    }

    public void Display()
    {
        Console.WriteLine($"{_name} - {_jNumber}");
    }
}