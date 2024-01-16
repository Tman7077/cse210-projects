using System;
using System.Globalization;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // prompt user to enter numbers into a list
        Console.WriteLine("Please enter numbers one by one, and enter 0 to quit.");
        
        List<float> numbers = new List<float>();
        
        // add numbers to a list as long as that number isn't zero
        float num = -1;
        do {
            Console.Write("Enter Number: ");
            num = float.Parse(Console.ReadLine());
            if (num != 0) {
                numbers.Add(num);
            }
        } while (num != 0);

        // calculate and display the sum of the list
        float sum = 0;
        foreach (float listItem in numbers) {
            sum += listItem;
        }
        Console.WriteLine($"The sum of your list is {sum}.");

        // calculate and display the average of the list
        float avg = 0;
        int numItems = 0;
        foreach (float listItem in numbers) {
            numItems += 1;
        }
        avg = sum / numItems;
        Console.WriteLine($"The average of your list is {avg}.");

        // calculate and display the max of the list
        float max = 0;
        foreach (float listItem in numbers) {
            if (listItem > max) {
                max = listItem;
            }
        }
        Console.WriteLine($"The highest number in your list is {max}.");

        // split the positive numbers into a separate list
        List<float> positiveNumbers = new List<float>();
        foreach (float listItem in numbers) {
            if (listItem > 0) {
                positiveNumbers.Add(listItem);
            }
        }

        // display the lowest positive value in the list
        positiveNumbers.Sort();
        Console.WriteLine($"The smallest positive number in your list is {positiveNumbers[0]}");

        // sort and display the sorted list
        numbers.Sort();
        Console.Write("Your sorted list is: ");
        foreach (float listItem in numbers) {
            Console.Write($"{listItem} ");
        }

    }
}