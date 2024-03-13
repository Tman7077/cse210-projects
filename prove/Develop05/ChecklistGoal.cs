class ChecklistGoal: Goal
{
    private int _bonus;
    private int _numToComplete;
    private int _numCompleted = 0;

    public ChecklistGoal(string name, string desc, int points, int numToComplete, int bonus): base(name, desc, points)
    {
        _numToComplete = numToComplete;
        _bonus = bonus;
        _numCompleted = 0;
    }
    public ChecklistGoal(string name, string desc, int points, int numToComplete, int bonus, int numCompleted): base(name, desc, points)
    {
        _numToComplete = numToComplete;
        _bonus = bonus;
        _numCompleted = numCompleted;
    }

    public override string GetSaveFormat()
    {
        return string.Join("|",("ChecklistGoal",GetBaseSaveFormat(),_bonus,_numToComplete,_numCompleted));
    }
    public override bool IsCompleted()
    {
        return _numCompleted == _numToComplete;
    }
    public override void Display()
    {
        base.Display();
        Console.Write($" ─ Completed: {_numCompleted}/{_numToComplete}");
    }
    public override void RecordEvent()
    {
        
    }
}