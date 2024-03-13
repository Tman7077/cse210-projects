class EternalGoal: Goal
{
    public EternalGoal(string name, string desc, int points): base(name, desc, points) {}

    public override string GetSaveFormat()
    {
        return string.Join("|",("EternalGoal",GetBaseSaveFormat()));
    }
    public override bool IsCompleted()
    {
        return false;
    }
}