using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteka.Database
{
    public class ReaderMap : IEntityTypeConfiguration<Reader>
    {
        public void Configure(EntityTypeBuilder<Reader> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("READER");
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            builder.Property(c => c.ReaderIndexNumber)
                .IsRequired()
                .HasColumnName("R_INDEX_NUMBER");
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnName("FIRST_NAME")
                .HasMaxLength(20);
            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnName("LAST_NAME")
                .HasMaxLength(40);
            builder.Property(c => c.AddressId)
                .HasColumnName("ADDRESS_ID");
            builder.Property(c => c.NumberOfBooks)
                .IsRequired()
                .HasColumnName("NUMBER_OF_BOOKS");

            builder.HasOne<Address>(c => c.Address).WithMany().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
