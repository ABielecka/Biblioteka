using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Biblioteka.Database
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        protected override DbSet<Country> DbSet => _dbContext.Countries;
        public CountryRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public Country GetCountry(string CountryName)
        {
            var country = DbSet.FirstOrDefault(c => c.Name.ToUpper().Equals(CountryName.ToUpper()));
            return country;
        }
    }
}
