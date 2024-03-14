class ChecklistGoal: Goal
{
    private int _numToComplete; // number of times to complete for a bonus
    private int _bonus;         // bonus points for completing _numToComplete times
    private int _numCompleted;  // number of times completed already

    // initialize a checklist goal, including its extra bits (called when creating a new goal)
    public ChecklistGoal(string name, string desc, int points, int numToComplete, int bonus): base(name, desc, points)
    {
        _numToComplete = numToComplete;
        _bonus = bonus;
        _numCompleted = 0;
    }
    // initialize a checklist goal, including its extra bits plus the number of times it has already been completed (called when reading a file)
    public ChecklistGoal(string name, string desc, int points, int numToComplete, int bonus, int numCompleted): base(name, desc, points)
    {
        _numToComplete = numToComplete;
        _bonus = bonus;
        _numCompleted = numCompleted;
    }

    // the string format that should be used when saving a checklist goal
    public override string GetSaveFormat()
    {
        return string.Join("|","ChecklistGoal",base.GetSaveFormat(),_numToComplete,_bonus,_numCompleted);
    }
    // return completion status (if number of times completed is equal to number of times needed to complete)
    public override bool IsCompleted()
    {
        return _numCompleted == _numToComplete;
    }
    // return partial completion status (if it has been completed at least once)
    public bool IsPartiallyCompleted()
    {
        return _numCompleted > 0 ? true : false;
    }
    // display the goal
    public override void Display()
    {
        // call the base display function, but add partial completion status to the end
        base.Display();
        Console.Write($" ─ Completed: {_numCompleted}/{_numToComplete}");
    }
    // record completion
    public override int RecordEvent()
    {
        // increase the number of times completed
        _numCompleted++;

        // call the base function to return points, and add bonus if complete
        return base.RecordEvent() + (IsCompleted() ? _bonus : 0);
    }
    // reset completion status
    public override int Reset()
    {
        int loss; // number of points lost by reset

        // if the goal has been entirely completed
        if (IsCompleted())
        {
            // multiply the base reset points times the number of times completed, and add the bonus
            loss = base.Reset() * _numCompleted + _bonus;
        }
        // if the goal has only been partially completed
        else
        {
            // multiply the base reset points times the number of times completed
            loss = base.Reset() * _numCompleted;
        }
        
        // reset numCompleted and return total point loss
        _numCompleted = 0;
        return loss;
    }
}