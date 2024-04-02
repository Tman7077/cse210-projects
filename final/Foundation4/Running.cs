class Running: Activity
{
    private float _distance;

    // initalize a Running by setting the distance and calling the base constructor
    public Running(string d, int m, float distance): base(d, m)
    {
        _distance = distance;
    }

    // return the stored distance, rounded to a decimal point
    public override float GetDistance()
    {
        return (float)Math.Round(_distance, 1);
    }
}