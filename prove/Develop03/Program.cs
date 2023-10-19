using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Reference verse = new Reference("Alma", "4", "15");
        string reference = verse.GetReference();
        string completeScripture = "And now it came to pass that Alma, having seen the afflictions of the humble followers of God, and the persecutions which were heaped upon them by the remainder of his people, and seeing all their inequality, began to be very sorrowful; nevertheless the Spirit of the Lord did not fail him.";
        Scripture scripture = new Scripture(reference, completeScripture);
        scripture.SplitWords();
        bool loop = true;

        while (loop) 
        {
            string text = scripture.GetWordString();
            bool proceed = Regex.IsMatch(text, @"[A-Z,a-z]");
            Console.Clear();
            scripture.Display();
            
            Console.WriteLine("\nPress enter to hide words, type quit to end program. ");
            var response = Console.ReadLine();
            if (response.ToLower() == "quit" || proceed == false)
            {
                loop = false;
            }
            else
            {
                scripture.HideWords(1);
            }
        }

        Console.WriteLine("Have a nice day!");
    }
}