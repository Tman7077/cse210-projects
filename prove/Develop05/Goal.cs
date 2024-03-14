abstract class Goal
{
    private string _name;        // the name of the goal
    private string _description; // the description of the goal
    private int _points;         // the points the goal is worth upon completion

    // initialize a Goal witha  given name, description, and point value
    protected Goal (string name, string desc, int points)
    {
        _name = name;
        _description = desc;
        _points = points;
    }

    // whether or not the goal is complete
    public abstract bool IsCompleted();
    // the string format that should be used when saving goals
    public virtual string GetSaveFormat()
    {
        return string.Join("|",_name,_description,_points);
    }
    // display goal with its completion marker preceding it
    public virtual void Display()
    {
        string x; // either "X" or " " depending upon completion state of the goal

        // define x based on completion state of the goal
        switch (IsCompleted())
        {
            case true: // complete
                x = "X";
                break;
            case false: // incomplete
                x = " ";
                break;
        }
        // Display a "checkbox," filled or empty (complete or incomplete), along with the name and description of the goal
        Console.Write($"[{x}] {_name} ({_description})");
    }
    // Record the completion of a goal, returning the points it is worth
    public virtual int RecordEvent()
    {
        return _points;
    }
    // Reset the progress towards a goal, returning the points it was worth
    public virtual int Reset()
    {
        return _points;
    }
}