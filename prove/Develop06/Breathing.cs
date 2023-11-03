public class Breathing : Activity
{

    public Breathing()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing. ";
    }


    public void BreathCount(string direction, int count)
    {
        int i = count;
        Console.Write($"{direction} {i}");
        while (i > 0)
        {
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i--;
            Console.Write(i);
        }
        Console.WriteLine();
    }

    public void BreatheActivity()
    {
        var intro = Intro();

        while (intro.Item1)
        {
            BreathCount("Breath In... ", 4);
            BreathCount("Breath Out... ", 6);
            intro.Item2 = DateTime.Now;
            if (intro.Item2 > intro.Item3)
            {
                intro.Item1 = false;
            }
        }

        Outro(intro.Item4);
    }

}