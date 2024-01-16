using System;

class Program
{
    static void Main(string[] args)
    {
        // welcome the user
        static void welcome() {
            Console.WriteLine("Welcome!");
        }

        // return the user's name
        static string getName() {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            return name;
        }

        // return the user's favorite number
        static float getNumber() {
            Console.Write("What is your favorite number? ");
            float number = float.Parse(Console.ReadLine());
            return number;
        }

        // return the given number (in this case, the user's favorite number) squared
        static double squareNumber(float num) {
            double numSquared = Math.Pow(num,2);
            return numSquared;
        }

        // display a message including the above elements
        static void displayResult(string name, float num, double numSquared) {
            Console.WriteLine($"{name}, your favorite number ({num}) squared is {numSquared}");
        }

        // call the above functions to make the program do its thing
        welcome();
        string name = getName();
        float num = getNumber();
        double numSquared = squareNumber(num);
        displayResult(name, num, numSquared);

    }
}