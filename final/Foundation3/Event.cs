abstract class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    protected Event(string title, string desc, string date, string time, Address address)
    {
        _title = title;
        _description = desc;
        _date = date;
        _time = time;
        _address = address;
    }

    public void DisplayStandardDetails()
    {
        Console.WriteLine($"Title: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress:\n{_address.GetAddress()}");
    }
    public void DisplayShortDescription()
    {
        Console.WriteLine($"Type: {this.GetType()}\nTitle: {_title}\nDate: {_date}"); 
    }
    public virtual void DisplayFullDetails()
    {
        DisplayStandardDetails();
    }
}