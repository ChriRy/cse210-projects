public class Activity
{
    protected string _name;
    protected string _description;

    public Activity()
    {
        _name = "";
        _description = "";
    }
    public (bool, DateTime, DateTime, int) Intro()
    {
        Console.WriteLine($"Welcome to the {_name} program!\n");
        Console.WriteLine($"{_description}\n");
        Console.WriteLine($"How long would you like to do the activity? ");
        int time = Convert.ToInt16(Console.ReadLine());

        int i = 3;
        Console.Write($"Starting in {i}");
        while (i > 0)
        {
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i--;
            Console.Write(i);
        }
        Console.WriteLine();

        bool loop = true;
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(time);

        return (loop, start, end, time);
    }

    public void Outro(int count)
    {
        Console.WriteLine($"\nGood job! You did this activity for {count} seconds. \n");
    }

    public void Timer(int time)
    {
        int i = 0;
        bool loop = true;
        string[] loading = { ".", "o", "0", "o", "." };
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(time);

        while (loop)
        {
            string dot = loading[i];
            Console.Write(dot);
            Thread.Sleep(100);
            Console.Write("\b \b");

            i++;
            if (i >= loading.Length)
            {
                i = 0;
            }
            start = DateTime.Now;
            if (start > end)
            {
                break;
            }
        }
    }

    public int GetRandom(List<string> list)
    {
        Random r = new Random();
        int i = r.Next(0, list.Count);
        return i;
    }


}