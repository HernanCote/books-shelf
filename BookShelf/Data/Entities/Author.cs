namespace BookShelf.Data.Entities;

public class Author
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Birthday { get; set; }
    public string CountryOfResidence { get; set; }
    public int HoursWritingPerDay { get; set; }
    public IEnumerable<Book> Books { get; set; }
}