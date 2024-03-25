class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer c)
    {
        _customer = c;
    }

    public void AddProduct(Product p)
    {
        _products.Add(p);
    }
    public double CalculateTotal()
    {
        float total = 5;
        foreach (Product p in _products)
        {
            total += (float)p.CalculateTotal();
        }
        if (!_customer.IsInUSA())
        {
            total += 30;
        }
        return Math.Round(total, 2);
    }
    public string GetShippingLabel()
    {
        return _customer.GetShippingInfo();
    }
    public string GetPackingLabel()
    {
        string label = "Packing slip:";
        foreach (Product p in _products)
        {
            label += "\n" + p.GetPackingInfo();
        }
        if (_customer.IsInUSA())
        {
            label += "\n" + "Shipping: $5";
        }
        else
        {
            label += "\n" + "Shipping: $35";
        }
        return label;
    }
}