using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteka.Database
{
    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("COUNTRY");
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("NAME")
                .HasMaxLength(30);
        }
    }
}