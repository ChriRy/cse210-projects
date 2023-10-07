using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        List<string> entries = new List<string>();
        bool loop = true;

        

        Console.WriteLine("Welcome to the Journal Program!");

        while (loop)
        {
        Console.WriteLine("Please select on of the following choices: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Add Prompt");
        Console.WriteLine("6. Quit");
        
        Console.WriteLine("What would you like to do?" );
        string userChoice = Console.ReadLine();
        Console.WriteLine();

            if (userChoice == "1" ) // Write
            {
                Entry entry1 = new Entry();
                (string,string,string) entryData = entry1.CreateEntry();
                entries.Add(entryData.Item1);
                entries.Add(entryData.Item2);
                entries.Add(entryData.Item3);
            }
            else if (userChoice == "2") // Display
            {
                foreach (string element in entries)
                {
                    Console.WriteLine(element);
                }
            }
            else if (userChoice == "3") // Load
            {
                Journal loadJournal = new Journal();
                loadJournal.LoadJournal();
            }
            else if (userChoice == "4") // Save
            {
                Journal saveJournal = new Journal();
                saveJournal.SaveJournal(entries);
            }
            else if (userChoice == "5")
            {
                Prompt addPrompt = new Prompt();
                addPrompt.AddPrompt();
            }
            else if (userChoice == "6") // Quit
            {
                Console.WriteLine("Goodbye!");
                loop = false;
            }

            Console.WriteLine();
        }    
    }
}