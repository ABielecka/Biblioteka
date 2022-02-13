using System;

namespace Biblioteka.Core
{
    public class BookDTO
    {
        public int BookIndexNumber { get; set; }
        public string Title { get; set; }
        public string YearofPublishment { get; set; }
        public bool isReturned { get; set; }

        public DateTime? ReturnDate { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
