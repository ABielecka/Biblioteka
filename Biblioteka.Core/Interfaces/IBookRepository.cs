using System.Collections.Generic;

namespace Biblioteka.Core
{
    public interface IBookRepository
    {
        public void Add(Book book);
        public void Remove(Book book);
        public ICollection<Book> GetAll();
        public Book GetBook(int index);
        public void Save();
    }
}
