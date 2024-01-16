using System;

class Program
{
    static void Main(string[] args)
    {
        int numPlays = 0; // number of times the game has been played
        string article = "a"; // string to denote whether the game has been played already
        bool play = false; // whether or not the player wants to play the game

        do {
            // if this is not the first time the player has played this session, change "a" to "another" to denote this
            if (numPlays > 0) {
                article = "another";
            }
            
            Console.WriteLine($"Would you like to guess {article} random number between 1 and 100? (yes/no)");
            string input = Console.ReadLine();
            bool readyToContinue = false; // whether the player has input a valid "yes" or "no"
            
            // determine whether the player would like to play (again, if necessary)
            do {
                if (input == "yes") {
                    play = true;
                    readyToContinue = true;
                } else if (input == "no") {
                    play = false;
                    readyToContinue = true;
                } else {
                    Console.WriteLine("Please answer \"yes\" or \"no\".");
                    input = Console.ReadLine();
                }
            } while (readyToContinue == false);

            // start the game
            if (play ==  true) {
                // generate number 1-100
                Random randomGenerator = new Random();
                int number = randomGenerator.Next(1, 101);

                Console.WriteLine("Magic number generated.");

                int guess; // player's guess
                int guesses = 0; // number of guesses the player has made
                do {
                    Console.WriteLine("What is your guess?");
                    guess = int.Parse(Console.ReadLine());
                    guesses++;
                    if (guess < number) {
                        Console.WriteLine("Higher!\n");
                    } else if (guess > number) {
                        Console.WriteLine("Lower!\n");
                    }
                } while (guess != number);

                //congratulate the player for guessing the number and tell them how bad they are at doing so
                Console.WriteLine($"Congratulations, you got it in {guesses} guesses!");
                numPlays++;
            } else {
                // do nothing, pass to the below
            }
            
        } while (play == true);

        Console.WriteLine("Thank you.");
    }
}