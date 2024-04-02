abstract class Event
{
    private string _title;       // name of event
    private string _description; // description of event
    private string _date;        // date on which event is scheduled
    private string _time;        // time at which event is scheduled
    private Address _address;    // location at which event is scheduled

    // initialize an Event, given the appropriate information (only called by subclasses)
    protected Event(string title, string desc, string date, string time, Address address)
    {
        _title = title;
        _description = desc;
        _date = date;
        _time = time;
        _address = address;
    }

    // display the type of event and some of its details (only common ones)
    public void DisplayShortDescription()
    {
        Console.WriteLine($"Type: {this.GetType()}\nTitle: {_title}\nDate: {_date}"); 
    }
    // display details that are present in every type of event
    public void DisplayStandardDetails()
    {
        Console.WriteLine($"Title: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress:\n{_address.GetAddress()}");
    }
    // display the above standard details, then let the overrides takke care of displaying the additional details
    public virtual void DisplayFullDetails()
    {
        DisplayStandardDetails();
    }
}