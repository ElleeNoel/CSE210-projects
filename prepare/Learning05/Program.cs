using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");
        Square square1 = new Square("blue", 7.90);
        Rectangle rectangle1 = new Rectangle("purple", 59, 8.66666);
        Circle circle1 = new Circle("yellow", 3.14);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square1);
        shapes.Add(rectangle1);
        shapes.Add(circle1);

        foreach (Shape shape in shapes)
        {
            Console.Write(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}