class Biking: Activity
{
    private float _speed;

    // initalize a Biking by setting the speed and calling the base constructor
    public Biking(string d, int m, float speed): base(d, m)
    {
        _speed = speed;
    }

    // return the stored speed, rounded to a decimal point
    public override float GetSpeed()
    {
        return (float)Math.Round(_speed, 1);
    }
}