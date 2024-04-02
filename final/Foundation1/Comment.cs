class Comment
{
    private string _author;  // commenter
    private string _content; // comment

    // initialize a Comment with a given author and comment content
    public Comment(string a, string c)
    {
        _author = a;
        _content = c;
    }

    // display the commenter and their comment
    public void Display()
    {
        Console.WriteLine($"{_author}: {_content}");
    }
}