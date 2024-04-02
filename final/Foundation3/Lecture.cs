class Lecture: Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string desc, string date, string time, Address address, string speaker, int capacity):
        base(title, desc, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }
    
    public override void DisplayFullDetails()
    {
        base.DisplayFullDetails();
        Console.WriteLine($"Speaker: {_speaker}\nMax capacity: {_capacity}");
    }
}