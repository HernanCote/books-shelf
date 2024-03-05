namespace BookShelf.Data.Entities;

public class Book
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string AuthorId { get; set; }
    public Author Author { get; set; }
    public Edition Edition { get; set; }
    public IEnumerable<Rating> Ratings { get; set; }
}