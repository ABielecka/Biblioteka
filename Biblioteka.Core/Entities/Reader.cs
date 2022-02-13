using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Core
{
    public class Reader : BaseEntity
    {
        public int ReaderIndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfBooks { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        [NotMapped]
        public virtual List<Rental> Rental { get; set; }
    }
}