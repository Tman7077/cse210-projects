class Order
{
    private List<Product> _products = new List<Product>(); // list of products (which include their quantities)
    private Customer _customer;                            // customer to which the order is addressed

    // initialize an order given a Customer
    public Order(Customer c)
    {
        _customer = c;
    }

    // add a given product to the list of products on the order
    public void AddProduct(Product p)
    {
        _products.Add(p);
    }
    // return the total, including the shipping cost (but not tax, cause who knows what tax is in each customer's location)
    public double CalculateTotal()
    {
        float total = 5; // total starts at 5 because shipping is always at least $5

        // add the cost of each Product (accounts for multiples) to the running total
        foreach (Product p in _products)
        {
            total += (float)p.CalculateTotal();
        }
        
        // $5 US shipping turns into $35 international shipping, hence the += 30
        if (!_customer.IsInUSA())
        {
            total += 30;
        }

        return Math.Round(total, 2);
    }
    // returns a printable shiping label (calls Customer method because the name and address are private)
    public string GetShippingLabel()
    {
        return _customer.GetShippingInfo();
    }
    // returns a printable packing slip, including each item's cost and quantity, plus shipping
    public string GetPackingLabel()
    {
        string label = "Packing slip:"; // start of packking slip

        // add each product's packing info on a new line
        foreach (Product p in _products)
        {
            label += "\n" + p.GetPackingInfo();
        }

        // if the customer is in the US, add $5 shipping
        if (_customer.IsInUSA())
        {
            label += "\n" + "Shipping: $5";
        }
        // if the customer is outside the US, add $35 shipping
        else
        {
            label += "\n" + "Shipping: $35";
        }
        
        return label;
    }
}