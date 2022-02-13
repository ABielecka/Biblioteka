using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.Database
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        protected override DbSet<Book> DbSet => _dbContext.Books;
        public BookRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }

        public override ICollection<Book> GetAll()
        {
            return DbSet.Include(c => c.Author)
                        .Include(c => c.BookType).ToList();
        }

        public Book GetBook(int index)
        {
            return DbSet.FirstOrDefault(c => c.BookIndexNumber == index);
        }
    }
}
