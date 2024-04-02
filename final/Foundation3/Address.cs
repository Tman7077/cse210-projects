class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string str, string ci, string sta, string co)
    {
        _street = str;
        _city = ci;
        _state = sta;
        _country = co;
    }
    
    public string GetAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}