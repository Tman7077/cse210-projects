class Biking: Activity
{
    private float _speed;
    
    public Biking(string d, int m, float speed): base(d, m)
    {
        _speed = speed;
    }

    public override float GetSpeed()
    {
        return (float)Math.Round(_speed, 1);
    }
}