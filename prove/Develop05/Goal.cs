abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    protected Goal (string name, string desc, int points)
    {
        _name = name;
        _description = desc;
        _points = points;
    }

    public abstract string GetSaveFormat();
    public abstract bool IsCompleted();

    protected string GetBaseSaveFormat()
    {
        return string.Join("|",(_name,_description,_points));
    }

    public virtual void Display()
    {
        string x;
        switch (IsCompleted())
        {
            case true:
                x = "X";
                break;
            case false:
                x = " ";
                break;
        }
        Console.Write($"[{x}] {_name} ({_description})");
    }
    public virtual void RecordEvent()
    {

    }
}