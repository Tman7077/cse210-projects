public abstract class Shape
{
    private string _color;

    protected Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public abstract double GetArea();
}