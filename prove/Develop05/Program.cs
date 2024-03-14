using System;

//www.plantuml.com/plantuml/png/pLF1JW8n4BttAvfuOGE4-uOO328nuIHwDcKxOcEttNIw94RzTplKfSKiCNlpqZ1lPjwyDymkq0ldsrepiKFlHELvfGKYNrkXsGURycSZQYXvI2gpfrW2LaurNbcJmurLncF9mylOrR5_bBTEUDQOmAojO6pCRnKsMhoFYf8Vh981cStu6lnM7E3EkbfuIiNka8hvUrpQkj7WGL9sPwsEkGUeh9Eh0nX_OlnYB5hSAkf9HgkE8pAGcbGor0iF90BXs7PMtfMHspxX0RrWDobVUN16w1_funJ_CvtBLwZUj4AVbhopfesZAJ9jVIAEOF__a8Y6MvpmCENHTdC6sEuvnakMUrVqrm4-8RYu5GnLS5h0FfZS1BCbftTEdgz93jMFYkx7YzAGRw9W_VC2IfA91JFiHag24jAv_LsuiK8cB1gWcCy_fzFy8qfWVfy9FR-61HZPrleR
/*
    exceeding core requirements:
    I added the ability to reset one or more goals, correctly reflecting lost points,
    while retaining the goals themselves, just marked incomplete.
*/
class Program
{
    static void Main(string[] args)
    {
        int choice = 0; // user's entry, should be 1-7
        int choices = 0; // number of times user has entered a choice

        // instantiate a User, to modify as the program progresses
        User user = new User();

        // function to repeat, allows the user to pick what they would like to do (create, load, save, etc.)
        do
        {
            user.DisplayScore();
            Console.WriteLine($"What {(choices == 0 ? "" : "else ")}would you like to do? Enter 1-7.");

            // display 7 options to the user, ask for input
            Console.WriteLine("  1. Create new goal");
            Console.WriteLine("  2. Display current goals");
            Console.WriteLine("  3. Save goals to a file");
            Console.WriteLine("  4. Load goals from a file");
            Console.WriteLine("  5. Record an event");
            Console.WriteLine("  6. Reset one or more goals");
            Console.WriteLine("  7. Quit");
            Console.Write("> ");
            choice = int.Parse(Console.ReadLine());

            // choose from 7 options based on user input
            switch (choice)
            {
                case 1: // create new goal
                    user.CreateGoal();
                    break;
                case 2: // display current goals
                    user.DisplayGoals();
                    break;
                case 3: // save goals to a file
                    user.SaveGoals();
                    break;
                case 4: // load goals from a file
                    user.LoadGoals();
                    break;
                case 5: // record an event
                    user.RecordEvent();
                    break;
                case 6: // reset one or more goals
                    user.Reset();
                    break;
                case 7: // quit
                    // set choice to 0 to break the while loop and exit
                    choice = 0;
                    break;
                default: // if choice variable is not a number from 1-6.
                    Console.WriteLine("\nPlease enter 1-7.\n");
                    choice = -1;
                    break;
            }
            choices++;
        } while (choice != 0);
    }
}