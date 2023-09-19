using System;

class Program
{
    static void Main(string[] args)
    {
        // bool loop = true;

        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,50);
        int guess = -1;
        int guess_count = 0;
        
        do 
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            guess_count++;

            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber) 
            {
                Console.WriteLine("Higher");
            }
            else if (guess == magicNumber)
            {
                Console.WriteLine("That's it!");
                Console.WriteLine($"It took you {guess_count} guesses!");

            }
        } while (guess != magicNumber);


    }
}