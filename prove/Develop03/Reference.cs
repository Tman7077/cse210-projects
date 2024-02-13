using System.Text.RegularExpressions;

public class Reference
{
    private string _book;
    private int _chapter;
    private int[] _verses = new int[2];

    // instantiates a Reference with sample content─ never used without later redefining it otherwise
    public Reference()
    {
        _book = "1 Nephi";
        _chapter = 3;
        _verses[0] = 7;
        _verses[1] = 7;
    }

    // instantiates a Reference given a book, chapter, start verse, and end verse (the latter two of which may be the same)
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verses[0] = startVerse;
        _verses[1] = endVerse;
    }

    // returns the reference as a string
    public string GetReference()
    {
        // if there is only one verse
        if (_verses[0] == _verses[1])
        {
            return $"{_book} {_chapter}:{_verses[0]}";
        }
        // if there are multiple verses
        else
        {
            return $"{_book} {_chapter}:{_verses[0]}-{_verses[1]}";
        }
    }

    // turns a reference as a string into a Reference object
    public Reference Parse(string reference)
    {
        string[] parts = reference.Split(new char[] {' ', ':'}, StringSplitOptions.RemoveEmptyEntries); // string array, splitting reference at spaces and colons
        List<string> partsList = parts.ToList(); // turns the string array into a list so it is mutable
        Regex number = new Regex("[0-9]+");      // regular expression to match any set of numbers (both 1 and 21 would be matched as one entity)

        // if the first entry in partsList is a number
        if (number.IsMatch(partsList[0]))
        {
            string newPart = partsList[0] + " " + partsList[1]; // combines the first and second entries in partsList (e.g. "2" + " " + "Nephi")

            // set the second entry in partsList to the 1+2 entry combo, then remove the first entry─
            // e.g. [2, Nephi, 32, 3] would become [2 Nephi, 32, 3]
            partsList[1] = newPart;
            partsList.RemoveAt(0);
        }

        string book = partsList[0];            // string containing the book (first entry in partsList)
        int chapter = int.Parse(partsList[1]); // parsed int containing the chapter (second entry in partsList)
        int[] verses = new int[2];             // int array for start and end verses
        
        // if there is a hyphen in the verse reference, denoting multiple verses
        if (partsList[2].Contains("-"))
        {
            string[] stringVerses = partsList[2].Split('-'); // string array, splitting verse reference at the hyphen

            // set the start and end verses from stringVerses
            verses[0] = int.Parse(stringVerses[0]);
            verses[1] = int.Parse(stringVerses[1]);
        }
        // if there is just one verse
        else
        {
            // set both the start and end verses to the same number
            verses[0] = int.Parse(partsList[2]);
            verses[1] = int.Parse(partsList[2]);
        }

        // instantiate and return a Reference object based on the determined book, chapter, and verse(s)
        return new Reference(book, chapter, verses[0], verses[1]);
    }

    // returns true if there is more than one verse in the reference, false if just one
    public bool IsMultipleVerses()
    {
        if (_verses[0] == _verses[1])
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // returns an int array containing the start and end verses
    public int[] GetVerses()
    {
        int[] verses = new int[2];
        verses[0] = _verses[0];
        verses[1] = _verses[1];
        return verses;
    }
}