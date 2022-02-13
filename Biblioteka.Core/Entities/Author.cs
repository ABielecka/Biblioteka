using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Core
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        [NotMapped]
        public virtual List<Book> Book { get; set; }
    }
}