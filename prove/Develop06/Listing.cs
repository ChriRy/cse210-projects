public class Listing : Activity
{

    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
    };

    public Listing()
    {
        _name = "Listing";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public void ListActivity()
    {
        var intro = Intro();
        Console.WriteLine(_prompts[GetRandom(_prompts)]);

        while (intro.Item1)
        {
            intro.Item2 = DateTime.Now;
            if (intro.Item2 > intro.Item3)
            {
                intro.Item1 = false;
            }
            Console.Write("- ");
            Console.ReadLine();
        }

        Outro(intro.Item4);
    }
}