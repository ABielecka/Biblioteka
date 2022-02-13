using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Core
{
    public class BookType : BaseEntity
    {
        public string Type { get; set; }

        [NotMapped]
        public virtual List<Book> Book { get; set; }
    }
}
