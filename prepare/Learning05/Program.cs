using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square sq = new Square("red", 2);
        Rectangle rec = new Rectangle("orange", 3, 4);
        Circle cir = new Circle("yellow", 5);

        List<Shape> shapes = new List<Shape>{sq, rec, cir};

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} {shape.GetArea()}");
        }
    }
}