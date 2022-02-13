using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteka.Database
{
    public class BookTypeMap : IEntityTypeConfiguration<BookType>
    {
        public void Configure(EntityTypeBuilder<BookType> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("BOOK_TYPE");
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            builder.Property(c => c.Type)
                .IsRequired()
                .HasColumnName("NAME")
                .HasMaxLength(20);
        }
    }
}
