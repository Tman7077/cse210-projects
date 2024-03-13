class ChecklistGoal: Goal
{
    private int _bonus;
    private int numCompleted;
    private bool _completed;

    public ChecklistGoal(string name, string desc, int points, int numToComplete): base(name, desc, points)
    {

    }

    public override string GetSaveFormat()
    {
        return "";
    }
    public override bool IsCompleted()
    {
        return false;
    }
    public override void Display()
    {

    }
    public override void RecordEvent()
    {
        
    }
}