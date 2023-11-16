using System.Security.Cryptography.X509Certificates;

public class Reflecting : Activity
{

    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
    };

    public Reflecting()
    {
        _name = "Reflecting";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public void ReflectActivity()
    {
        var intro = Intro();

        Console.WriteLine(_prompts[GetRandom(_prompts)]);
        Timer(5);
        int i = GetRandom(_questions);

        while (intro.Item1)
        {
            intro.Item2 = DateTime.Now;
            if (intro.Item2 > intro.Item3)
            {
                intro.Item1 = false;
            }
            var questions = GetQuestion(i);
            i = questions.Item2;
            Console.WriteLine(questions.Item1);
            i++;
            Timer(5);
        }

        Outro(intro.Item4);
    }
    
    public (string, int) GetQuestion(int i)
    {
        if (i >= _questions.Count)
        {
            i = 0;
        }
        return (_questions[i], i);
    }


}