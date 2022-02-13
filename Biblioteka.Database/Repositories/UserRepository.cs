using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.Database
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        protected override DbSet<User> DbSet => _dbContext.Users;
        public UserRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }
        public override ICollection<User> GetAll()
        {
            return DbSet.Include(c => c.Role).ToList();
        }
    }
}
