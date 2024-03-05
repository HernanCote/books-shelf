namespace BookShelf.Schema;

public class AuthorType
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Birthday { get; set; }
    public string CountryOfResidence { get; set; }
    public int HoursWritingPerDay { get; set; }
}