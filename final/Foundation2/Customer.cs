class Customer
{
    private string _name;     // customer's name
    private Address _address; // customer's address

    // initialize a Customer given its required attributes
    public Customer(string n, Address a)
    {
        _name = n;
        _address = a;
    }

    // return whether or not the customer lives in the US (calls the Address method because the country is private)
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
    // returns a printable shipping label, with the name and address
    public string GetShippingInfo()
    {
        return $"{_name}\n" + _address.GetAddress();
    }
}