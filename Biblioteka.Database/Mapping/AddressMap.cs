using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteka.Database
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("ADDRESS");
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            builder.Property(c => c.PostalCode)
                .IsRequired()
                .HasColumnName("POSTAL_CODE")
                .HasMaxLength(6);
            builder.Property(c => c.City)
                .IsRequired()
                .HasColumnName("CITY")
                .HasMaxLength(20);
            builder.Property(c => c.Street)
                .IsRequired()
                .HasColumnName("STREET")
                .HasMaxLength(20);
            builder.Property(c => c.Number)
                .IsRequired()
                .HasColumnName("NUMBER");
            //builder.Property(c => c.ReaderID)
            //    .HasColumnName("READER_ID");

            //builder.HasOne<Reader>(c => c.Reader).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
