class Product
{
    private string _name;
    private int _id;
    private float _price;
    private int _quantity;

    public Product(string n, int i, double p, int q)
    {
        _name = n;
        _id = i;
        _price = (float)p;
        _quantity = q;
    }

    public double CalculateTotal()
    {
        return Math.Round(_quantity * _price, 2);
    }
    public string GetPackingInfo()
    {
    return $"{_name} ({_id}): {_quantity} @ ${_price}/ea";
    }
}