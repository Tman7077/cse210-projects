class SimpleGoal: Goal
{
    private bool _completed; // whether or not the goal has been completed
    
    // inititalize a new simple goal, incomplete by default (called when creating a new goal)
    public SimpleGoal(string name, string desc, int points): base(name, desc, points) 
    {
        _completed = false;
    }
    // inititalize a new simple goal, completion status included (called when reading a file)
    public SimpleGoal(string name, string desc, int points, bool completed): base(name, desc, points)
    {
        _completed = completed;
    }

    // the string format that should be used when saving a simple goal
    public override string GetSaveFormat()
    {
        return string.Join("|","SimpleGoal",base.GetSaveFormat(),_completed);
    }
    // return completion status
    public override bool IsCompleted()
    {
        return _completed;
    }
    // record completion
    public override int RecordEvent()
    {
        // set _completed to true, and call the base function to return points
        _completed = true;
        return base.RecordEvent();
    }
    // reset completion status
    public override int Reset()
    {
        // set _completed to false, and call the base function to return points
        _completed = false;
        return base.Reset();
    }
}