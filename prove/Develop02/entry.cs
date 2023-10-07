public class Entry {

    public (string, string, string) CreateEntry() 
    {
        string date = GetDate();
        string prompt = GetPrompt();
        Console.WriteLine($"{date}");
        Console.WriteLine($"{prompt}");
        string input = GetUserEntry();

        return (date,prompt,input);
    }
    public string GetDate() 
    {
        DateTime date = new DateTime();
        string currentDate = date.ToShortDateString();
        return currentDate;
    }

    public string GetPrompt() 
    {
        Prompt newPrompt = new Prompt();
        string stringPrompt = newPrompt.GetRandomPrompt().ToString();
        return stringPrompt;
    }

    public string GetUserEntry() {
        string input = Console.ReadLine();
        return input;
    }

}