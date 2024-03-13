class EternalGoal: Goal
{
    public EternalGoal(string name, string desc, int points): base(name, desc, points) {}

    public override string GetSaveFormat()
    {
        return "";
    }
    public override bool IsCompleted()
    {
        return false;
    }
}