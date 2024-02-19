using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Tyler Bartle", "Example Assignment");
        Console.WriteLine(assignment1.GetSummary());
        
        MathAssignment assignment2 = new MathAssignment("Tyler Bartle", "Example Assignment", "5", "1-2");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());

        WritingAssignment assignment3 = new WritingAssignment("Tyler Bartle", "Example Assignment", "Example Title");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInfo());
    }
}