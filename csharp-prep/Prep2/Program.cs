using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What percentage did you receive in this class?");
        string percentAsString = Console.ReadLine();
        int percent = int.Parse(percentAsString);

        string letter;
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string article;
        if (letter == "A" || letter == "F")
        {
            article = "an";
        }
        else
        {
            article = "a";
        }

        string passFail;
        if (percent >= 70)
        {
            passFail = "passed";
        }
        else
        {
            passFail = "failed";
        }

        int lastDigit = percent % 10;
        string modifier;
        if (lastDigit >=7)
        {
            modifier = "+";
        }
        else if (lastDigit <=3)
        {
            modifier = "-";
        }
        else
        {
            modifier = "";
        }

        if ((letter == "A" && modifier == "+") || letter == "F")
        {
            modifier = "";
        }
        else
        {
            // leave "modifier" as it is
        }
        
        Console.WriteLine($"You {passFail}, with {article} {letter}{modifier}.");
    }
}