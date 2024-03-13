abstract class Goal
{
    private string _name;
    private string _description;
    private int points;

    protected Goal (string name, string desc, int points)
    {

    }

    public abstract string GetSaveFormat();
    public abstract bool IsCompleted();

    public virtual void Display()
    {

    }
    public virtual void RecordEvent()
    {

    }
}