using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();
        int number = -1;
        float sum = 0;
        int max = -1;
        int min = 9999999;
        int length = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished. ");

        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            numberList.Add(number);
        } while (number != 0);

        

        foreach (int integer in numberList)
        {
            sum += integer;
            if (integer != 0)
            {
                length++;
            }
            if (integer > max)
            {
                max = integer;
            }
            if(integer < min && integer > 0)
            {
                min = integer;
            }
        }


        float average = sum / length;

        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest number is {max}");
        Console.WriteLine($"The smallest positive number is {min}");

    }
}