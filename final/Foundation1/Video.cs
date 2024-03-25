using System.Transactions;

class Video
{
    private string _title;
    private string _author;
    private string _length;
    private List<Comment> _comments = new List<Comment>();

    public Video(string t, string a, int l)
    {
        _title = t;
        _author = a;
        TimeSpan length = TimeSpan.FromSeconds(l);
        _length = $"{length:hh}:{length:mm}:{length:ss}";
    }

    public void AddComment(Comment c)
    {
        _comments.Add(c);
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"\"{_title}\" by {_author} ({_length})");
        if (_comments.Count() > 0)
        {
            Console.WriteLine($"{_comments.Count()} Comments:");
            foreach (Comment c in _comments)
            {
                c.Display();
            }
        }
        else
        {
            Console.WriteLine("No comments.");
        }
    }
}