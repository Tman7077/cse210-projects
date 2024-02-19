public class WritingAssignment : Assignment
{
    private string _title;

    // public WritingAssignment() : base()
    // {
    //     _title = "Sample Title";
    // }
    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }

    public string GetWritingInfo()
    {
        return $"{_title} by {GetName()}";
    }
}