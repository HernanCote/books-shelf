namespace BookShelf.Data;

using Entities;
using Microsoft.EntityFrameworkCore;
using ModelConfiguration;

public class BookShelfContext : DbContext
{
    public BookShelfContext(DbContextOptions options) : base(options) {}
    
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new EditionConfiguration());
        modelBuilder.ApplyConfiguration(new RatingConfiguration());
    }
    
}