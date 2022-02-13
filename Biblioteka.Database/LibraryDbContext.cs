using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Database
{
    public class LibraryDbContext :DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Role>  Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseOracle("Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = tcp)(HOST = ANNA-1)(PORT = 1521))(CONNECT_DATA = (SERVICE_NAME = XE))); User Id = LIBRARY; Password=Losos123;");
            //optionsBuilder.UseSqlServer("Server = A-NNA\\MSSQLSERVER_ANNA;Database=LibraryDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new AuthorMap());
            modelBuilder.ApplyConfiguration(new BookMap());
            modelBuilder.ApplyConfiguration(new BookTypeMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new ReaderMap());
            modelBuilder.ApplyConfiguration(new RentalMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
