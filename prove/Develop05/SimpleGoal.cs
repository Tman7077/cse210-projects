class SimpleGoal: Goal
{
    private bool _completed;
    
    public SimpleGoal(string name, string desc, int points): base(name, desc, points) {}

    public override string GetSaveFormat()
    {
        return "";
    }
    public override bool IsCompleted()
    {
        return false;
    }
}