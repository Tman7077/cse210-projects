public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // public MathAssignment() : base()
    // {
    //     _textbookSection = "0";
    //     _problems = "0-0";
    // }
    public MathAssignment(string name, string topic, string section, string problems) : base(name, topic)
    {
        _textbookSection = section;
        _problems = problems;
    }
    
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} problems {_problems}";
    }
}