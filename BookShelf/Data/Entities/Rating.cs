namespace BookShelf.Data.Entities;

public class Rating
{
    public int Id { get; set; }
    public string BookId { get; set; }
    public Book Book { get; set; }
    
    public int ReviewId { get; set; }
    public int ReviewerId { get; set; }
    public decimal Value { get; set; }
}