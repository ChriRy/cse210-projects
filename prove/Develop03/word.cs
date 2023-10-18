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

    public string Hide()
    {
        int count = _word.Length;
        string hiddenWord = "";
        for (int i=0; i<count;i++)
        {
            hiddenWord = $"{hiddenWord}_";
        }
        return hiddenWord;
    }
}
