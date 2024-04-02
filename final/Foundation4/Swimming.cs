class Swimming: Activity
{
    private int _laps; // number of laps across the pool

    // initalize a Swimming by setting the laps and calling the base constructor
    public Swimming(string d, int m, int laps): base(d, m)
    {
        _laps = laps;
    }

    // return the calculated distance, rounded to a decimal point
    public override float GetDistance()
    {
        return (float)Math.Round(_laps * 50 / 1000 * 0.62, 1);
    }
}