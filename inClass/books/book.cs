using System.ComponentModel.DataAnnotations;
using System.Net;

namespace books;

public class Book
{
    private string _author;
    private string _name;
    private int _timesRead;
    private bool _available;

    public Book(string author, string name)
    {
        _author = author;
        _name = name;
        _timesRead = 0;
        _available = true;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_name}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Times Read: {_timesRead}");
        if (!_available)
        {
            Console.WriteLine($"Availability: Checked Out");
        }
        else
        {
            Console.WriteLine($"Availability: Currently Available");
        }
    }

    public void CheckOut()
    {
        _available = false;
    }

    public void CheckIn()
    {
        _available = true;
        _timesRead++;
    }

    public bool HasAuthor(string author)
    {
        return _author.Contains(author);
    }

    public int TimesRead()
    {
        return _timesRead;
    }

    public bool IsAvailable()
    {
        return _available;
    }
}
