namespace BookShelf.Schema;

using Data.Entities;

public class BookType
{
    public string Id { get; set; }
    public string Title { get; set; }
    public AuthorType Author { get; set; }
    public IEnumerable<Rating> Ratings { get; set; }
    public Edition Edition { get; set; }
}