public class Fraction
{
    private int _num;
    private int _denom;

    public Fraction()
    {
        _num = 1;
        _denom = 1;
    }

    public Fraction(int num)
    {
        _num = num;
        _denom = 1;
    }

    public Fraction(int num, int denom)
    {
        _num = num;
        _denom = denom;
    }

    public int GetNum()
    {
        return _num;
    }

    public void SetNum(int num)
    {
        _num = num;
    }

    public int GetDenom()
    {
        return _denom;
    }

    public void SetDenom(int denom)
    {
        _denom = denom;
    }

    public string GetFraction()
    {
        return $"{_num}/{_denom}";
    }

    public double GetDecimal()
    {
        return (double)_num / (double)_denom;
    }
}