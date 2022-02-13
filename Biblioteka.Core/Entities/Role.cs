using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteka.Core
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        [NotMapped]
        public virtual List<User> User { get; set; }
    }
}
