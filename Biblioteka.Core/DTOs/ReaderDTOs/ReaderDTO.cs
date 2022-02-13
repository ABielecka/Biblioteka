using System.Collections.Generic;

namespace Biblioteka.Core
{
    public class ReaderDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Rental> Rental { get; set; }
    }
}
