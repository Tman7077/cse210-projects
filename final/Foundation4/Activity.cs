abstract class Activity
{
    private string _date; // date
    private int _minutes; // duration

    // initialize an Activity given its attributes
    protected Activity(string d, int m)
    {
        _date = d;
        _minutes = m;
    }

    // return the distance traveled over the course of the activity (overridden if distance is stored)
    public virtual float GetDistance()
    {
        return (float)Math.Round(GetSpeed() * _minutes / 60, 1);
    }
    // return the average speed over the course of the activity (overridden if speed is stored)
    public virtual float GetSpeed()
    {
        return (float)Math.Round(GetDistance() / _minutes * 60, 1);
    }
    // return the average pace over the course of the activity
    public float GetPace()
    {
        return (float)Math.Round(60 / GetSpeed(), 1);
    }
    // display a summary of the activity, calling the above functions
    public void GetSummary()
    {
        Console.WriteLine($"{_date}: {GetType()} ({_minutes} min)─ Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile.");
    }
}