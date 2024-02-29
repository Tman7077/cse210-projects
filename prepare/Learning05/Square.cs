public class Square: Shape
{
    private double _side = 1;

    public Square(string color, double s): base(color)
    {
        _side = s;
    }

    public override double GetArea()
    {
        return Math.Pow(_side, 2);
    }
}