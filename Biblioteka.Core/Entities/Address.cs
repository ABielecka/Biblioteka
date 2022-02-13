using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Core
{
    public class Address : BaseEntity
    {
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }

        //public int ReaderID { get; set; }
        [NotMapped]
        public virtual Reader Reader { get; set; }
    }
}