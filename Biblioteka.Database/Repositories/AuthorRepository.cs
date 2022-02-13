using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.Database
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        protected override DbSet<Author> DbSet => _dbContext.Authors;
        public AuthorRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public override ICollection<Author> GetAll()
        {
            return DbSet.Include(c => c.Country).ToList();
        }

        public Author GetAuthor(string FirstName, string LastName, string CountryName)
        {
            var author = DbSet.FirstOrDefault(c => c.FirstName.ToUpper().Equals(FirstName.ToUpper()) 
                                          && c.LastName.ToUpper().Equals(LastName.ToUpper()) 
                                          && c.Country.Name.ToUpper().Equals(CountryName.ToUpper()));
            return author;
        }
    }
}
