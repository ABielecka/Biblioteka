using System;

namespace Biblioteka.Core
{
    public class Rental : BaseEntity
    {
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public long? Overdue { get; set; }
        public long? Fine { get; set; }

        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int ReaderId { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
