class EternalGoal: Goal
{
    // initialize an eternal goal, just calls base constructor
    public EternalGoal(string name, string desc, int points): base(name, desc, points) {}

    // the string format that should be used when saving an eternal goal
    public override string GetSaveFormat()
    {
        return string.Join("|","EternalGoal",base.GetSaveFormat());
    }
    // return completion status (always false, or incomplete)
    public override bool IsCompleted()
    {
        return false;
    }
}