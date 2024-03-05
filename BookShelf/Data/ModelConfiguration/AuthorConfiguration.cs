namespace BookShelf.Data.ModelConfiguration;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.FirstName).IsRequired();
        builder.Property(a => a.LastName).IsRequired();
        builder.Property(a => a.Birthday).IsRequired();
        builder.Property(a => a.CountryOfResidence).IsRequired();
        builder.Property(a => a.HoursWritingPerDay).IsRequired();
    }
}