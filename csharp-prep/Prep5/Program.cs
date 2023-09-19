using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        float number = PromptUserNumber();
        float number_squared = SquareNumber(number);
        DisplayResult(name,number_squared);

        
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.Write("What is your name? ");
            string username = Console.ReadLine();
            return username;
        }

        static int PromptUserNumber()
        {
            Console.Write("What is your favorite number? ");
            int userNumber = int.Parse(Console.ReadLine());
            return userNumber;
        }

        static float SquareNumber(float fav_number)
        {
            double squared = Math.Pow(fav_number, 2);
            float num_squared = (float)squared;
            return num_squared;
        }

        static void DisplayResult (string name, float squaredNumber)
        {
            Console.Write($"{name}, the square of your favorite number is {squaredNumber}");
        }
    }
}