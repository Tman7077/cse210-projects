class Lecture: Event
{
    private string _speaker;
    private int _capacity;

    // initialize a Lecture by setting the speaker and capacity and calling the base constructor
    public Lecture(string title, string desc, string date, string time, Address address, string speaker, int capacity):
        base(title, desc, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }
    
    // call base function for base info, and display additional relevant info
    public override void DisplayFullDetails()
    {
        base.DisplayFullDetails();
        Console.WriteLine($"Speaker: {_speaker}\nMax capacity: {_capacity}");
    }
}