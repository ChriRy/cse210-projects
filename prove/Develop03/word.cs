using System.Text.RegularExpressions;

public class Word
{
    private string _word;

    public Word(string word)
    {
        _word = word;
    }

    public string Show()
    {
        return _word;
    }

    public string Hide(string word)
    {
        word = Regex.Replace(word, @"[A-Z,a-z]","_");
        return word;
    }
}
