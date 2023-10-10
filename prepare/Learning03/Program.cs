using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction one = new Fraction();
        Fraction whole = new Fraction(3);
        Fraction fraction = new Fraction(1,4);

        Console.WriteLine(one.GetFractionString());
        whole.SetTop(5);
        Console.WriteLine(whole.GetFractionString());
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
    }
}