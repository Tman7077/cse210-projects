class OutdoorGathering: Event
{
    private string _forecast;

    // initialize an OutdoorGathering by setting the forecast and calling the base constructor
    public OutdoorGathering(string title, string desc, string date, string time, Address address, string forecast):
        base(title, desc, date, time, address)
    {
        _forecast = forecast;
    }
    
    // call base function for base info, and display additional relevant info
    public override void DisplayFullDetails()
    {
        base.DisplayFullDetails();
        Console.WriteLine($"Forecast: {_forecast}");
    }
}