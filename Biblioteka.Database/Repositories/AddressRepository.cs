using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Database
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        protected override DbSet<Address> DbSet => _dbContext.Addresses;
        public AddressRepository(LibraryDbContext dbContext) : base(dbContext)
        {

        }
    }
}
