using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka.Database
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        protected override DbSet<Role> DbSet => _dbContext.Roles;
        public RoleRepository(LibraryDbContext dbContext) : base(dbContext)
        {
        }
    }
}
