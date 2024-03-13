class SimpleGoal: Goal
{
    private bool _completed = false;
    
    public SimpleGoal(string name, string desc, int points): base(name, desc, points) {}
    public SimpleGoal(string name, string desc, int points, bool completed): base(name, desc, points)
    {
        _completed = completed;
    }

    public override string GetSaveFormat()
    {
        return string.Join("|",("SimpleGoal",GetBaseSaveFormat(),_completed));
    }
    public override bool IsCompleted()
    {
        return _completed;
    }
}