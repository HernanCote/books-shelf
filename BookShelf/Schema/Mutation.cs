namespace BookShelf.Schema;

using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

public class Mutation
{
    public async Task<BookType> CreateBook([Service] BookShelfContext context, string title, string authorId)
    {
        var author = await context.Authors.Where(x => x.Id == authorId).FirstOrDefaultAsync();

        if (author is null)
            return null;
        
        var book = new Book
        {
            Id = Guid.NewGuid().ToString(),
            Title = title,
            AuthorId = authorId
        };
        
        context.Books.Add(book);
        await context.SaveChangesAsync();

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