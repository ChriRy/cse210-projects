
using System.Text.RegularExpressions;
public class Scripture
{
    private string _reference;

    private string _completeScripture = "15 And now it came to pass that Alma, having seen the afflictions of the humble followers of God, and the persecutions which were heaped upon them by the remainder of his people, and seeing all their inequality, began to be very sorrowful; nevertheless the Spirit of the Lord did not fail him.";
    private List<string> _wordList = new List<string>();

    public Scripture(string reference)
    {
        
    }

    public void SortPunctuation()
    {
        string pattern = @"\W";
        string[] words = _completeScripture.Split();
        foreach (string word in words)
        {
            if (Regex.IsMatch(word, pattern))
            {
                int length = word.Length;
                char punctuation = word[length-1];
                string onlyWord = word.Remove(length-1, 1);
                _wordList.Add(onlyWord);
                _wordList.Add(Convert.ToString(punctuation));
            }
            else
            {
                _wordList.Add(word);
            }
        }
    }

    public void HideWords()
    {

    }

    public void Display()
    {
        SortPunctuation();
        foreach (string word in _wordList)
        {
            Console.Write($"{word} ");
        }
    }

}