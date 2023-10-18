using System;

class Program
{
    static void Main(string[] args)
    {
        Reference verse = new Reference("Alma1", "4", "15");

        Scripture scripture = new Scripture(verse.GetReference());

        scripture.Display();
    }
}