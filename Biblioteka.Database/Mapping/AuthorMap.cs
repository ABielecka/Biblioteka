using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteka.Database
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("AUTHOR");
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnName("FIRST_NAME");
            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnName("LAST_NAME")
                .HasMaxLength(50);
            builder.Property(c => c.CountryId)
                .HasColumnName("COUNTRY_ID");

            builder.HasOne<Country>(c => c.Country).WithMany().IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
