using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Square shape1 = new Square(2);
        Rectangle shape2 = new Rectangle(2, 3);
        Circle shape3 = new Circle(4);

        List<Shape> shapes = new List<Shape>() { shape1, shape2, shape3 };

        foreach (Shape item in shapes)
        {
            Console.WriteLine(item.GetArea());
        }
    }
}