using System.Transactions;

class Video
{
    private string _title;                                 // title of video
    private string _author;                                // poster of video
    private string _length;                                // length of video in seconds
    private List<Comment> _comments = new List<Comment>(); // list of comments on the video

    // initialize a Video given its attributes, not including comments
    public Video(string t, string a, int l)
    {
        _title = t;
        _author = a;

        // turns 100 seconds into 00:01:40, or 1000 seconds into 00:16:40, etc.
        TimeSpan length = TimeSpan.FromSeconds(l);
        _length = $"{length:hh}:{length:mm}:{length:ss}";
    }

    // adds a Comment to the list of comments
    public void AddComment(Comment c)
    {
        _comments.Add(c);
    }
    // displays the video's information, followed by each comment's information
    public void DisplayInfo()
    {
        Console.WriteLine($"\"{_title}\" by {_author} ({_length})");

        // display the number of comments, followed by the comments themselves, including the author
        Console.WriteLine($"{_comments.Count()} Comments:");
        foreach (Comment c in _comments)
        {
            c.Display();
        }
    }
}