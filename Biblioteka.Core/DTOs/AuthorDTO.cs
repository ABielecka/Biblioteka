using System.Collections.Generic;

namespace Biblioteka.Core
{
    public class AuthorDTO
    {
        public string Name { get; set; }
        public List<Book> Book { get; set; }
    }
}
