using System.Collections.Generic;

namespace Biblioteka.Core
{
    public interface IAuthorRepository
    {
        public void Add(Author Author);
        public void Update(Author author);
        public ICollection<Author> GetAll();
        public Author GetAuthor(string FirstName, string LastName, string CountryName);
        public void Save();
    }
}
