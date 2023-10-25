using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop04 World!");

        Assignment assignment = new Assignment("Ryan Christensen", "Programming in C#");
        assignment.GetSummary();

        MathAssignment calculus = new MathAssignment("Travis Erickson", "Calculus", "7.3", "1-4, 18-26");
        calculus.GetSummary();
        calculus.GetHomeworkList();

        WritingAssignment biology = new WritingAssignment("Adam Christensen", "Biology", "The Powerhouse of the Cell");
        biology.GetSummary();
        biology.GetWritingInformation();
    }
}