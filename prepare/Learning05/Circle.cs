public class Circle: Shape
{
    private double _radius = 1;

    public Circle(string color, double r): base(color)
    {
        _radius = r;
    }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}