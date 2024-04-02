class Reception: Event
{
    private string _rsvpAddress;

    public Reception(string title, string desc, string date, string time, Address address, string rsvp):
        base(title, desc, date, time, address)
    {
        _rsvpAddress = rsvp;
    }

    public override void DisplayFullDetails()
    {
        base.DisplayFullDetails();
        Console.WriteLine($"RSVP at {_rsvpAddress}");
    }
}