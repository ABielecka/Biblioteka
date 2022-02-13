using Biblioteka.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.Database
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        protected LibraryDbContext _dbContext;
        protected abstract DbSet<T> DbSet { get; }

        public BaseRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Add(T data)
        {
            DbSet.Add(data);
            Save();
        }

        public virtual ICollection<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual void Update(T data)
        {
            _dbContext.Entry(data).State = EntityState.Modified;
        }

        public virtual void Remove(T data)
        {
            var foundData = DbSet.FirstOrDefault(c => c.Id == data.Id);
            if (foundData != null)
            {
                DbSet.Remove(foundData);
                Save();
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
