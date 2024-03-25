class Comment
{
    private string _author;
    private string _content;

    public Comment(string a, string c)
    {
        _author = a;
        _content = c;
    }

    public void Display()
    {
        Console.WriteLine($"{_author}: {_content}");
    }
}