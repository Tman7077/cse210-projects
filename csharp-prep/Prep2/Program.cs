using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        // set var percent based on the percent supplied by user
        Console.WriteLine("What percentage did you receive in this class?");
        string percentAsString = Console.ReadLine();
        int percent = int.Parse(percentAsString);

        string letter;
        // set var letter to the appropriate letter grade based on the percent grade
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
        // set var article to the appropriate article based on the letter grade
        if (letter == "A" || letter == "F")
        {
            article = "an";
        }
        else
        {
            article = "a";
        }

        string passFail;
        // set var passFail to the appropriate value based on the percent grade
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
        //set var modifier to either "+", "-", or nothing based on the last digit of the percent grade
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

        // set var modifier to be nothing if it would be an A+, F+, or F-
        if ((letter == "A" && modifier == "+") || letter == "F")
        {
            modifier = "";
        }
        else
        {
            // leave "modifier" as it is
        }
        
        // display the user message based on the above
        Console.WriteLine($"You {passFail}, with {article} {letter}{modifier}.");
    }
}