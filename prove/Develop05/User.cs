using System.IO;
class User
{
    private int _score;           // total number of points the user has earned
    private List<Goal> _goalList; // list of goals stored in memory, either loaded from a file or created by the user

    // initialize a blank user, with no points or goals
    public User()
    {
        _score = 0;
        _goalList = new List<Goal>();
    }

    // create some type of goal
    public void CreateGoal()
    {
        int choice = 0; // the user's input, to select a goal type

        // ensure the user selects a valid option
        do
        {
            // display 3 options to the user, ask for input
            Console.WriteLine("What kind of goal would you like to create? Enter 1-3.");
            Console.WriteLine("  1. Simple goal");
            Console.WriteLine("  2. Eternal goal");
            Console.WriteLine("  3. Checklist goal");
            Console.Write("> ");
            choice = int.Parse(Console.ReadLine());

            // either allow to continue, or restart the do/while loop if choice is invalid
            switch (choice)
            {
                case 1: case 2: case 3:
                    break;
                default:
                    Console.WriteLine("Please enter 1-3.");
                    choice = 0;
                    break;
            }
        } while (choice == 0);
        
        // collect the name, description, and point value, which are common between all goal types
        Console.WriteLine("What is the name of your goal?");
        Console.Write("> ");
        string name = Console.ReadLine();

        Console.WriteLine("Please write a short description of your goal.");
        Console.Write("> ");
        string desc = Console.ReadLine();

        Console.WriteLine("How many points is completing this goal worth?");
        Console.Write("> ");
        int points = int.Parse(Console.ReadLine());

        // create a goal, based on the user's previous type selection (choice)
        switch (choice)
        {
            case 1: // simple goal
                _goalList.Add(new SimpleGoal(name, desc, points));
                break;
            case 2: // eternal goal
                _goalList.Add(new EternalGoal(name, desc, points));
                break;
            case 3: // checklist goal
                // collect the additional information needed for a checkklist goal
                Console.WriteLine("How many times would you like to complete this goal?");
                Console.Write("> ");
                int numToComplete = int.Parse(Console.ReadLine());

                Console.WriteLine($"How many bonus points is completing this goal {numToComplete} times worth?");
                Console.Write("> ");
                int bonus = int.Parse(Console.ReadLine());

                _goalList.Add(new ChecklistGoal(name, desc, points, numToComplete, bonus));
                break;
        }
    }
    // Display a list of all goals in a given list
    public void DisplayGoals(List<Goal> goalList = null)
    {
        // if there is no input list of goals, use _goalList instead
        // (this isn't the argument default in the function definition
        // because _goalList isn't a compile-time constant)
        if (goalList == null)
        {
            goalList = _goalList;
        }

        int i = 1; // counter for displaying numbered goals

        // display each goal in the given list, numbered
        foreach (Goal goal in goalList)
        {
            Console.Write($"{i}. ");
            goal.Display();
            Console.Write("\n");
            i++;
        }
    }
    // save the currently loaded goals to a file (chosen by the user)
    public void SaveGoals()
    {
        // ask the user for the filename
        Console.WriteLine("Please write the name of the file to which you would like to save your goals.");
        Console.Write("> ");
        string filename = Console.ReadLine();

        List<string> lines = new List<string> {_score.ToString()}; // list of lines to write, starting with the user's score

        // add each goal, given its specific save format, as a line to lines
        foreach (Goal goal in _goalList)
        {
            lines.Add(goal.GetSaveFormat());
        }

        // write each line in lines to the given text file
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (string line in lines)
            {
                file.WriteLine(line);
            }
        }
    }
    // load goals from a text file, either overwriting currently loaded goals or adding onto them
    public void LoadGoals()
    {
        string overwrite = "no"; // whether to overwrite currently loaded goals
        string add = "no";       // whether to add to currently loaded goals

        // if there are already goals loaded
        if (_goalList.Count() > 0)
        {
            do
            {
                // ask the user if they would like to overwrite the currently loaded goals
                Console.WriteLine($"You have {_goalList.Count()} goal{(_goalList.Count() == 1 ? "" : "s")} loaded already. Would you like to overwrite them? Write \"yes\" or \"no\".");
                Console.Write("> ");
                overwrite = Console.ReadLine();

                // choose to overwrite or not depending on above choice
                switch (overwrite)
                {
                    case "yes": // overwrite
                        // set _goalList to blank, so new goals can be added below
                        _goalList = new List<Goal>();
                        break;
                    case "no": // don't overwrite
                        do
                        {
                            // ask the user if they would like to add current goals to those in a file
                            Console.WriteLine($"Would you like to add {(_goalList.Count() == 1 ? "it" : "them")} to the goal(s) from a file? Write \"yes\" or \"no\".");
                            Console.Write("> ");
                            add = Console.ReadLine();

                            // choose to add or not depending on above choice
                            switch (add)
                            {
                                case "yes": // add
                                    break;
                                case "no": // don't add (or overwrite)
                                    Console.WriteLine("Taking you back to the main menu.");
                                    break;
                                default: // invalid choice, try again
                                    Console.WriteLine("Please write \"yes\" or \"no\".");
                                    add = "loop";
                                    break;
                            }
                        } while (add == "loop");
                        break;
                    default: // invalid choice, try again
                        Console.WriteLine("Please write \"yes\" or \"no\".");
                        overwrite = "loop";
                        break;
                }
            } while (overwrite == "loop");
        }

        // if _goalList is empty (because it was empty before or the user would like to overwrite its entries),
        // or if the user would like to add entries to it
        if (_goalList.Count() == 0 | add == "yes")
        {
            // ask the user for the filename
            Console.WriteLine("Please write the name of the file from which you would like to load your goals.");
            Console.Write("> ");
            string filename = Console.ReadLine();

            // set _score to the first line of the file
            _score = int.Parse(System.IO.File.ReadLines(filename).First());

            // for each line in the file, ignoring the first line
            foreach (string line in System.IO.File.ReadLines(filename).Skip(1))
            {
                string[] parts = line.Split("|"); // string array of the split parts of the line
                string goalType = parts[0];       // the type of goal object to create, as a string

                // choose what goal type to create based on goalType
                switch (goalType)
                {
                    case "SimpleGoal": // simple goal
                        _goalList.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                        break;
                    case "EternalGoal": // eternal goal
                        _goalList.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal": // checklist goal
                        _goalList.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                        break;
                }
            }
        }
    }
    // record progress towards a goal
    public void RecordEvent()
    {
        // if there are no goals for which to mark progress
        if (_goalList.Count() == 0)
        {
            Console.WriteLine("You have no goals to mark complete!");
            return;
        }

        // list of incomplete goals (the ones that can be marked complete)
        List<Goal> incompleteGoals = new List<Goal>();

        // add each incomplete goal to incompleteGoals
        foreach (Goal goal in _goalList)
        {
            if (!goal.IsCompleted())
            {
                incompleteGoals.Add(goal);
            }
        }

        // display all incomplete goals
        Console.WriteLine("Your incomplete goals:");
        DisplayGoals(incompleteGoals);

        // ask the user which goal they would like to record progress towards
        Console.WriteLine($"Please select a number from 1-{incompleteGoals.Count()}, corresponding to the goal for which you would like to record completion.");
        int index = int.Parse(Console.ReadLine()) - 1;

        // record progress for the aforementioned goal, add the appropriate points to _score, and congratulate the user
        int score = incompleteGoals[index].RecordEvent();
        _score += score;
        Console.WriteLine($"Congratulations! You earned {score} points.");
    }
    // reset the progress towards one goal or all goals
    public void Reset()
    {
        bool canReset = false; // if it is possible to reset any progress

        // check if any goals are marked as entirely completed, and update canReset accordingly
        foreach (Goal goal in _goalList)
        {
            if (goal.IsCompleted())
            {
                canReset = true;
                break;
            }
            else
            {
                continue;
            }
        }

        // if no goals are entirely completed, check if any ChecklistGoals are partially completed, and update canReset accordingly
        if (canReset == false)
        {
            foreach (ChecklistGoal goal in _goalList.OfType<ChecklistGoal>())
            {
                if (goal.IsPartiallyCompleted())
                {
                    canReset = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        // if there are no goals to reset progress towards
        // (it is possible to have points from eternal goals; however, since they
        // are never "complete", they are unable to be reset by this function)
        if (canReset == false)
        {
            Console.WriteLine("You have no goals with progress to reset!");
        }
        // if there is progress to be reset
        else
        {
            int choice = 0; // user's entry, should be 1 or 2
            do
            {
                // display 2 options to the user, ask for input
                Console.WriteLine("What would you like to do? Enter 1 or 2.");
                Console.WriteLine("  1. Reset a single goal");
                Console.WriteLine("  2. Reset all progress");
                Console.Write("> ");
                choice = int.Parse(Console.ReadLine());

                // reset a single goal or all goals based on above choice
                switch (choice)
                {
                    case 1: // reset a single goal
                        // empty list of goals, to be filled with goals that can be reset
                        List<Goal> completeGoals = new List<Goal>();

                        // add each completed simple goal to completeGoals
                        foreach (SimpleGoal goal in _goalList.OfType<SimpleGoal>())
                        {
                            if (goal.IsCompleted())
                            {
                                completeGoals.Add(goal);
                            }
                        }

                        // add each completed or partially completed checklist goal to completeGoals
                        foreach (ChecklistGoal goal in _goalList.OfType<ChecklistGoal>())
                        {
                            if (goal.IsPartiallyCompleted())
                            {
                                completeGoals.Add(goal);
                            }
                        }

                        // display all complete (or partially complete) goals
                        Console.WriteLine("Your complete (or partially complete) goals:");
                        DisplayGoals(completeGoals);

                        // ask the user for the goal to reset and reset it
                        Console.WriteLine($"Please select a number from 1-{completeGoals.Count()}, corresponding to the goal for which you would like to reset progress.");
                        int index = int.Parse(Console.ReadLine()) - 1;
                        int loss = completeGoals[index].Reset();

                        // subtract all score gained from the reset goal from the user's _score, adn inform the user of that loss
                        _score -= loss;
                        Console.WriteLine($"You reset a goal and lost {loss} points.");
                        break;
                    case 2: // reset all progress
                        // reset all goals in _goalList
                        foreach (Goal goal in _goalList)
                        {
                            goal.Reset();
                        }
                        // inform the user that all goals have been reset and that their score is now 0.
                        Console.WriteLine($"You reset all of your goals, and lost {_score} points.");
                        _score = 0;
                        break;
                    default: // invalid choice, try again
                        Console.WriteLine("\nPlease enter 1 or 2.\n");
                        choice = -1;
                        break;
                }
            } while (choice == -1);
        }
    }
    // display the user's score
    public void DisplayScore()
    {
        Console.WriteLine($"\nYour score: {_score.ToString()}\n");
    }
}