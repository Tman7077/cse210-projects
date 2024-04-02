abstract class Activity
{
    private string _date;
    private int _minutes;

    protected Activity(string d, int m)
    {
        _date = d;
        _minutes = m;
    }

    public virtual float GetDistance()
    {
        return (float)Math.Round(GetSpeed() * _minutes / 60, 1);
    }
    public virtual float GetSpeed()
    {
        return (float)Math.Round(GetDistance() / _minutes * 60, 1);
    }
    public float GetPace()
    {
        return (float)Math.Round(60 / GetSpeed(), 1);
    }
    public void GetSummary()
    {
        Console.WriteLine($"{_date}: {GetType()} ({_minutes} min)─ Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min per mile.");
    }
}