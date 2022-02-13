using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Core
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
