using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteka.Database
{
    public class RentalMap : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("RENTAL");
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            builder.Property(c => c.RentalDate)
                .IsRequired()
                .HasColumnName("RENTAL_DATE");
            builder.Property(c => c.ReturnDate)
                .IsRequired()
                .HasColumnName("RETURN_DATE");
            builder.Property(c => c.IsReturned)
                .IsRequired()
                .HasColumnName("IS_RETURNED");
            builder.Property(c => c.Overdue)
                .HasColumnName("OVERDUE_TIME");
            builder.Property(c => c.Fine)
                .HasColumnName("FINE");
            builder.Property(c => c.BookId)
                .HasColumnName("BOOK_ID");
            builder.Property(c => c.ReaderId)
                .HasColumnName("READER_ID");

            builder.HasOne<Book>(c => c.Book).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Reader>(c => c.Reader).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
