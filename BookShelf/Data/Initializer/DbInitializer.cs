namespace BookShelf.Data.Initializer;

using System.Text.Json;
using BookShelf.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class DbInitializer
{
    public static void InitializeDatabase(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<BookShelfContext>());
    }

    private static void SeedData(BookShelfContext context)
    {
        context.Database.Migrate();

        if (context.Books.Any())
            return;

        using StreamReader booksReader = new("Data/Initializer/Books.json");
        var booksJson = booksReader.ReadToEnd();
        var books = JsonSerializer.Deserialize<List<Book>>(booksJson);
        context.Books.AddRange(books);
        
        using StreamReader authReader = new("Data/Initializer/Authors.json");
        var json = authReader.ReadToEnd();
        var authors = JsonSerializer.Deserialize<List<Author>>(json);
        context.Authors.AddRange(authors);
        
        using StreamReader ratingReader = new("Data/Initializer/Rating.json");
        var ratingJson = ratingReader.ReadToEnd();
        var ratings = JsonSerializer.Deserialize<List<Rating>>(ratingJson);
        context.Ratings.AddRange(ratings);
        
        using StreamReader editionReader = new("Data/Initializer/Edition.json");
        var editionJson = editionReader.ReadToEnd();
        var editions = JsonSerializer.Deserialize<List<Edition>>(editionJson);
        context.Editions.AddRange(editions);

        context.SaveChanges();
    }
}