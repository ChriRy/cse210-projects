using books;

class Bookcase
{
    List<Book> _books;

    public void ShowBooks()
    {
        foreach (Book book in _books)
        {
            book.Display();
        }
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void CountBooks()
    {
        Console.WriteLine($"We have {_books.Count()} books.");
    }

    

}