class Reception: Event
{
    private string _rsvpAddress; // email address at which to rsvp

    // initialize a Reception by setting the rsvp address and calling the base constructor
    public Reception(string title, string desc, string date, string time, Address address, string rsvp):
        base(title, desc, date, time, address)
    {
        _rsvpAddress = rsvp;
    }

    // call base function for base info, and display additional relevant info
    public override void DisplayFullDetails()
    {
        base.DisplayFullDetails();
        Console.WriteLine($"RSVP at {_rsvpAddress}");
    }
}