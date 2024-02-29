public class Rectangle: Shape
{
    private double _length = 1;
    private double _width = 1;

    public Rectangle(string color, double l, double w): base(color)
    {
        _length = l;
        _width = w;
    }

    public override double GetArea()
    {
        return _length * _width;
    }
}