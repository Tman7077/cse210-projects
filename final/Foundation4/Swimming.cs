class Swimming: Activity
{
    private int _laps;

    public Swimming(string d, int m, int laps): base(d, m)
    {
        _laps = laps;
    }
    
    public override float GetDistance()
    {
        return (float)Math.Round(_laps * 50 / 1000 * 0.62, 1);
    }
}