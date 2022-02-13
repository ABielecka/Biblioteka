using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteka.Database
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("USER");
            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnName("FIRST_NAME")
                .HasMaxLength(20);
            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnName("LAST_NAME")
                .HasMaxLength(40);
            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("EMAIL")
                .HasMaxLength(20);
            builder.Property(c => c.PasswordHash)
                .IsRequired()
                .HasColumnName("PASSWORD");
            builder.Property(c => c.RoleId)
                .HasColumnName("ROLE_ID");

            builder.HasOne<Role>(c => c.Role).WithOne().IsRequired().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
