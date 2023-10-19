
using System.Diagnostics;
using System.Text.RegularExpressions;
public class Scripture
{
    private string _reference;

    private string _completeScripture = "15 And now it came to pass that Alma, having seen the afflictions of the humble followers of God, and the persecutions which were heaped upon them by the remainder of his people, and seeing all their inequality, began to be very sorrowful; nevertheless the Spirit of the Lord did not fail him.";
    private string[] _wordList;

    public Scripture(string reference, string completeScripture)
    {
        _reference = reference;
        _completeScripture = completeScripture;
    }

    public void SplitWords()
    {
        _wordList = _completeScripture.Split(" ");
    }

    public string GetWordString()
    {
        string result = String.Concat(_wordList);
        return result;
    }

    public void HideWords(int number)
    {
        for (int i=0;i<number;i++)
        {
            Random rnd = new Random();
            int index = (int) rnd.Next(0,_wordList.Length);
            string word = _wordList[index];
            if (Regex.IsMatch(word, "[_]"))
            {
                i -= 1;
            }
            else
            {
                Word hide = new Word(word);
                _wordList[index] = hide.Hide(word);
            }
        }
    }

    public void Display()
    {
        Console.WriteLine("\n====================================================================\n");
        Console.WriteLine($"{_reference}");
        foreach (string word in _wordList)
        {
            Console.Write($"{word} ");
        }
        Console.WriteLine("\n====================================================================\n");
    }

    // public void Display()
    // {
    //     Console.WriteLine("====================================================================\n");
    //     Console.WriteLine();
    //     SortPunctuation();
    //     foreach (string word in _wordList)
    //     {
    //         Console.Write($"{word} ");
    //     }
    //     Console.WriteLine("\n");
    //     Console.WriteLine("====================================================================");
    // }

}       // public void SortPunctuation()
    // {
    //     string pattern = @"\W";
    //     string[] words = _completeScripture.Split();
    //     foreach (string word in words)
    //     {
    //         if (Regex.IsMatch(word, pattern))
    //         {
    //             int length = word.Length;
    //             char punctuation = word[length-1];
    //             string onlyWord = word.Remove(length-1, 1);
    //             _wordList.Add(onlyWord);
    //             _wordList.Add(Convert.ToString(punctuation));
    //         }
    //         else
    //         {
    //             _wordList.Add(word);
    //         }
    //     }
    // }
