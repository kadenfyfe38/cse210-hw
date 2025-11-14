using System;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("blue", 10);
        string x = square.GetColor();
        Console.WriteLine(x);
        double squareArea = square.GetArea();
        Console.WriteLine(squareArea);

        Rectangle rectangle = new Rectangle("red", 5, 7);
        string rectColor = rectangle.GetColor();
        double rectArea = rectangle.GetArea();
        Console.WriteLine($"{rectColor}, {rectArea}");

        Circle circle = new Circle("orange", 4);
        string circleColor = circle.GetColor();
        double circleArea = circle.GetArea();
        Console.WriteLine($"{circleColor}, {circleArea}");

        List<Shape> shapes = new List<Shape>() { square, rectangle, circle };
        
        foreach(Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"Color: {color}, Area: {area}");
        }
    
    }
}