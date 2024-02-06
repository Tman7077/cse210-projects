using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac1 = new Fraction();
        Fraction frac2 = new Fraction(2);
        Fraction frac3 = new Fraction(1,7);
        Console.WriteLine($"{frac1.GetNum()}");
        Console.WriteLine($"{frac1.GetDenom()}");
        Console.WriteLine($"{frac1.GetFraction()}");
        Console.WriteLine($"{frac1.GetDecimal()}");
        Console.WriteLine($"{frac2.GetNum()}");
        Console.WriteLine($"{frac2.GetDenom()}");
        Console.WriteLine($"{frac2.GetFraction()}");
        Console.WriteLine($"{frac2.GetDecimal()}");
        Console.WriteLine($"{frac3.GetNum()}");
        Console.WriteLine($"{frac3.GetDenom()}");
        Console.WriteLine($"{frac3.GetFraction()}");
        Console.WriteLine($"{frac3.GetDecimal()}");
    }
}