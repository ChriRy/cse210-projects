using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter your grade: ");
        int grade = int.Parse(Console.ReadLine());

        if (grade >= 90) 
        {
            string letterGrade = "A";

            int sign = grade % 10;
            if (sign < 3)
            {
                string gradeSign = "-";
                Console.WriteLine($"Your grade is {letterGrade}{gradeSign}.");
            }
            else
            {
                Console.WriteLine($"Your grade is {letterGrade}.");
            }

        }
        else if (grade < 90 && grade >= 80)
        {
            string letterGrade = "B";
                        int sign = grade % 10;
            if (sign < 3)
            {
                string gradeSign = "-";
                Console.WriteLine($"Your grade is {letterGrade}{gradeSign}.");
            }
            else if (sign >= 7)
            {
                string gradeSign = "+";
                Console.WriteLine($"Your grade is {letterGrade}{gradeSign}.");
            }
            else
            {
                Console.WriteLine($"Your grade is {letterGrade}.");
            }
        }
        else if (grade < 80 && grade >= 70)
        {
            string letterGrade = "C";
                        int sign = grade % 10;
            if (sign < 3)
            {
                string gradeSign = "-";
                Console.WriteLine($"Your grade is {letterGrade}{gradeSign}.");
            }
            else if (sign >= 7)
            {
                string gradeSign = "+";
                Console.WriteLine($"Your grade is {letterGrade}{gradeSign}.");
            }
            else
            {
                Console.WriteLine($"Your grade is {letterGrade}.");
            }
        }
        else if (grade < 70 && grade >= 60)
        {
            string letterGrade = "D";
                        int sign = grade % 10;
            if (sign < 3)
            {
                string gradeSign = "-";
                Console.WriteLine($"Your grade is {letterGrade}{gradeSign}.");
            }
            else if (sign >= 7)
            {
                string gradeSign = "+";
                Console.WriteLine($"Your grade is {letterGrade}{gradeSign}.");
            }
            else
            {
                Console.WriteLine($"Your grade is {letterGrade}.");
            }
        }
        else 
        {
            string letterGrade = "F";
            Console.WriteLine($"Your grade is {letterGrade}.");

        }

        if (grade > 70)
        {
            Console.WriteLine("Good job, you passed!");
        }
        else 
        {
            Console.WriteLine("Better luck next time. ");
        }
    }
}