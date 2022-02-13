using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.Database
{
    public class RentalRepository : BaseRepository<Rental>, IRentalRepository
    {
        protected override DbSet<Rental> DbSet => _dbContext.Rentals;
        public RentalRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public override ICollection<Rental> GetAll()
        {
            return DbSet.Include(c => c.Book)
                        .Include(c => c.Reader)
                        .ToList();
        }

        public ICollection<Rental> Get(int index)
        {
            return GetAll().Where(c => c.Book.BookIndexNumber == index).ToList();
        }
    }
}
