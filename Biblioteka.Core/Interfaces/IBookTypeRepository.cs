using System.Collections.Generic;

namespace Biblioteka.Core
{
    public interface IBookTypeRepository
    {
        public void Add(BookType bookType);
        public void Update(BookType bookType);
        public ICollection<BookType> GetAll();
        public void Save();
    }
}
