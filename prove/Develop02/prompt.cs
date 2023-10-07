public class Prompt
{
    //Prompt list
    public List<string> promptList = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    //prompt methods
    public void AddPrompt()
    {
        Console.WriteLine("Please enter the prompt: ");
        string newPrompt = Console.ReadLine();
        promptList.Add(newPrompt);
    }

    public string GetRandomPrompt()
    {
        int length = promptList.Count();
        Random rnd = new Random();
        int num = rnd.Next(0,(length - 1));
        return promptList[num];
    }
}