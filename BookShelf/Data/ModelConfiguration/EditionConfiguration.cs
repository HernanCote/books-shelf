namespace BookShelf.Data.ModelConfiguration;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EditionConfiguration : IEntityTypeConfiguration<Edition>
{
    public void Configure(EntityTypeBuilder<Edition> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.BookId).IsRequired();
        builder.Property(e => e.ISBN).IsRequired();
        builder.Property(e => e.Format).IsRequired();
        builder.Property(e => e.PubId).IsRequired();
        builder.Property(e => e.PublicationDate).IsRequired();
        builder.Property(e => e.Pages).IsRequired();
        builder.Property(e => e.PrintRunSize).IsRequired();
        builder.Property(e => e.Price).IsRequired();
    }
}