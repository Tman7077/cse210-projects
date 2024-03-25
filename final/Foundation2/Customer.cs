class Customer
{
    private string _name;
    private Address _address;

    public Customer(string n, Address a)
    {
        _name = n;
        _address = a;
    }

    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
    public string GetShippingInfo()
    {
        return $"{_name}\n" + _address.GetAddress();
    }
}