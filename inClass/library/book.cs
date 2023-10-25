public class Book : Loanable
{
    private string _title;
    private string _isbn;
    private int _upc;

    public Book(string title, string isbn, int upc)
    {
        _title = title;
        _isbn = isbn;
        _upc = upc;
    }

    public override void Display()
    {
        ShowBookDetails();
    }

    public void ShowBookDetails()
    {
        Console.WriteLine($"{_title} : {_isbn} :: {_upc} : Available: {_isCheckedIn}");
    }
}