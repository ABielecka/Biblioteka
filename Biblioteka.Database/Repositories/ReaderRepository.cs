using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Biblioteka.Database
{
    public class ReaderRepository : BaseRepository<Reader>, IReaderRepository
    {
        protected override DbSet<Reader> DbSet => _dbContext.Readers;
        public ReaderRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public Reader GetReader(int index)
        {
            var temp =  DbSet.FirstOrDefault(c => c.ReaderIndexNumber == index && c.NumberOfBooks <= 5);

            return temp;
        }
    }
}