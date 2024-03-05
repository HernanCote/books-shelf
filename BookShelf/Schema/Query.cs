namespace BookShelf.Schema;

using Data;
using Microsoft.EntityFrameworkCore;

public class Query
{
    
    [UseFiltering]
    public async Task<IEnumerable<BookType>> GetBooks([Service] BookShelfContext context)
    {
        var books = await context.Books
            .Include(b => b.Author)
            .Include(x => x.Edition)
            .Select(b => new BookType
            {
                Id = b.Id,
                Title = b.Title,
                Author = new AuthorType
                {
                    Id = b.Author.Id,
                    Birthday = b.Author.Birthday,
                    CountryOfResidence = b.Author.CountryOfResidence,
                    FirstName = b.Author.FirstName,
                    LastName = b.Author.LastName,
                    HoursWritingPerDay = b.Author.HoursWritingPerDay
                },
                Edition = b.Edition
            })
            .ToListAsync();

        return books;
    }

    public async Task<BookType> GetBookByTitle([Service] BookShelfContext context, string title)
    {
        var book = await context.Books
            .Include(b => b.Author)
            .Include(b => b.Edition)
            .FirstOrDefaultAsync(b => b.Title == title);

        var bookType = new BookType
        {
            Id = book.Id,
            Title = book.Title,
            Author = new AuthorType
            {
                Birthday = book.Author.Birthday,
                CountryOfResidence = book.Author.CountryOfResidence,
                FirstName = book.Author.FirstName,
                LastName = book.Author.LastName,
                HoursWritingPerDay = book.Author.HoursWritingPerDay
            }
        };

        return bookType;
    }
}