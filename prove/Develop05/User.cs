class User
{
    private int _score;
    private List<Goal> _goalList;

    public User()
    {
        _score = 0;
        _goalList = new List<Goal>();
    }
    public User(string filename)
    {

    }

    public void CreateGoal()
    {
        int choice = 0;
        Console.WriteLine("What kind of goal would you like to create? Enter 1-3.");
        Console.WriteLine("  1. Simple goal");
        Console.WriteLine("  2. Eternal goal");
        Console.WriteLine("  3. Checklist goal");
        Console.Write("> ");
        choice = int.Parse(Console.ReadLine());

        Console.WriteLine("What is the name of your goal?");
        Console.Write("> ");
        string name = Console.ReadLine();

        Console.WriteLine("Please write a short description of your goal.");
        Console.Write("> ");
        string desc = Console.ReadLine();

        Console.WriteLine("How many points is completing this goal worth?");
        Console.Write("> ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1: // simple goal
                _goalList.Add(new SimpleGoal(name, desc, points));
                break;
            case 2: // eternal goal
                _goalList.Add(new EternalGoal(name, desc, points));
                break;
            case 3: // checklist goal
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
    public void DisplayGoals()
    {
        int i = 1;
        foreach (Goal goal in _goalList)
        {
            Console.Write($"{i}. ");
            goal.Display();
            Console.Write("\n");
            i++;
        }
    }
    public void SaveGoals()
    {

    }
    public void LoadGoals()
    {

    }
    public void RecordEvent()
    {

    }
}