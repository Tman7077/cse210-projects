class Address
{
    private string _street;  // number and street name
    private string _city;    // city
    private string _state;   // state / province
    private string _country; // country

    // initialize an Address, given each of its attributes
    public Address(string str, string ci, string sta, string co)
    {
        _street = str;
        _city = ci;
        _state = sta;
        _country = co;
    }

    // return whether or not the country is USA
    public bool IsInUSA()
    {
        return _country == "USA";
    }
    // return the whole address, as a correctly formatted string
    public string GetAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}