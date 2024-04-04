class Product
{
    private string _name;  // name of product
    private int _id;       // product id, an 8-char int
    private float _price;  // price in USD
    private int _quantity; // number of this product to be included in the order

    // initialize a Product, given its applicable attributes
    public Product(string n, int i, double p, int q)
    {
        _name = n;
        _id = i;
        _price = (float)p;
        _quantity = q;
    }

    // return the total based on the price and quantity, making sure to round to two decimals just in case
    public double CalculateTotal()
    {
        return Math.Round(_quantity * _price, 2);
    }
    // return a string in the format displayed on a packing label
    public string GetPackingInfo()
    {
    return $"{_name} ({_id:00000000}): {_quantity} @ ${_price:.00}/ea";
    }
}