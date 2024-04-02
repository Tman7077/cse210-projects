class Running: Activity
{
    private float _distance;

    public Running(string d, int m, float distance): base(d, m)
    {
        _distance = distance;
    }
    
    public override float GetDistance()
    {
        return (float)Math.Round(_distance, 1);
    }
}