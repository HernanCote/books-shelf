namespace BookShelf.Data.Entities;

public class Edition
{
    public int Id { get; set; }
    public string BookId { get; set; }
    public Book Book { get; set; }
    public string ISBN { get; set; }
    public string Format { get; set; }
    public string PubId { get; set; }
    public string PublicationDate { get; set; }
    public int Pages { get; set; }
    public int PrintRunSize { get; set; }
    public string Price { get; set; }
}