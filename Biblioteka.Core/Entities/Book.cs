using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Core
{
    public class Book : BaseEntity
    {
        public int BookIndexNumber { get; set; }
        public string Title { get; set; }
        public string YearofPublishment { get; set; }
        public string Language { get; set; }
        public bool isReturned { get; set; }
        public bool? Status { get; set; }

        public int BookTypeId { get; set; }
        public virtual BookType BookType { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [NotMapped]
        public virtual Rental Rental { get; set; }
    }
}
