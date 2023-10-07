using System.IO;

public class Journal {
    

    
    public void SaveJournal(List<string> entries) 
    {
        Console.WriteLine("What file would you like to save to? ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName)) 
        {
            foreach (string element in entries)
            {
                outputFile.WriteLine(element);
            }
        }
    }

    public void LoadJournal()
    {
        Console.WriteLine("What is the filename of the journal? ");
        string filename = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Console.WriteLine($"{line}");
        }
    }

}