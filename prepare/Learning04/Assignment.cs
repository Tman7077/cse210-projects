public class Assignment
{
    private string _studentName;
    private string _topic;

    // public Assignment()
    // {
    //     _studentName = "Student A";
    //     _topic = "Homework";
    // }
    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    protected string GetName()
    {
        return _studentName;
    }
    public string GetSummary()
    {
        return $"{_studentName}: {_topic}";
    }
}