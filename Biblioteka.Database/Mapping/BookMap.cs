using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteka.Database
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("BOOK");
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            builder.Property(c => c.BookIndexNumber)
                .IsRequired()
                .HasColumnName("B_INDEX_NUMBER");
            builder.Property(c => c.Title)
                .IsRequired()
                .HasColumnName("TITLE")
                .HasMaxLength(30);
            builder.Property(c => c.YearofPublishment)
                .IsRequired()
                .HasColumnName("YEAR")
                .HasMaxLength(4);
            builder.Property(c => c.Language)
                .IsRequired()
                .HasColumnName("LANGUGE")
                .HasMaxLength(15);
            builder.Property(c => c.isReturned)
                .IsRequired()
                .HasColumnName("IS_RETURNED");
            builder.Property(c => c.Status)
                .HasColumnName("STATUS");
            builder.Property(c => c.BookTypeId)
                .HasColumnName("BOOK_TYPE_ID");
            builder.Property(c => c.AuthorId)
                .HasColumnName("AUTHOR_ID");

            builder.HasOne<BookType>(c => c.BookType).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Author>(c => c.Author).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
