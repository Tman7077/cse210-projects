using System.Text.RegularExpressions;

public class Word
{
    private string _word;

    // instantiates a Word given a word as a string
    public Word(string word)
    {
        _word = word;
    }

    // replace a given word with underscores
    public string Hide()
    {
        Regex letters = new Regex("[A-Za-z]"); // regular expression to match individual letters ("abc" would match 3 times, not once)

        // replace each letter with an underscore─
        // the regex preserves (verse) numbers and punctuation
        return letters.Replace(_word,"_");
    }
}