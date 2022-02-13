using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Database
{
    public class BookTypeRepository : BaseRepository<BookType>, IBookTypeRepository
    {
        protected override DbSet<BookType> DbSet => _dbContext.BookTypes;
        public BookTypeRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
