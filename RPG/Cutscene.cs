
using System.Collections;
using System.Data;
using System.IO;
using System.Reflection.PortableExecutable;
public class Cutscene
{
    string _file;

    public Cutscene(string file)
    {
        _file = file;
        RunCutscene(_file);
    }

    public void RunCutscene(string file)
    {
        string[] lines = System.IO.File.ReadAllLines(file);
        foreach (string line in lines)
        {
            int speed = 25;
            string[] parts = line.Split("|");
            string speaker = parts[0];
            string color = parts[1];
            string text = parts[2];

            if (speaker == "Narrator")
            {
                Console.Write($"\u001b[{color}m");
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(speed);
                }
            }
            else
            {
                Console.WriteLine($"[{speaker}]");
                Console.Write($"----> \u001b[{color}m");
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(speed);
                }
            }
            Console.WriteLine("\u001b[0m");
            string input = Console.ReadLine()!;
            if (input == "s")
            {
                break;
            }
        }

        Console.WriteLine("Press enter to continue... ");
        Console.ReadLine();
        Console.Clear();
    }

}