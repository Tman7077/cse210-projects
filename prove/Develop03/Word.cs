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

    public bool IsHidden()
    {
        Regex numbersOrUnderscores = new Regex("[0-9+|_+]"); // regular expression to match any set of numbers or underscores ("1", "12", "_", and "__" would each match once)

        // if _word has either numbers or underscores in it
        if (numbersOrUnderscores.IsMatch(_word))
        {
            return true;
        }
        // if _word has neither numbers nor underscores in it
        else
        {
            return false;
        }
    }
}