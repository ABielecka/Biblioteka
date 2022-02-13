using System.Collections.Generic;

namespace Biblioteka.Core
{
    public interface IRoleRepository
    {
        public void Add(Role role);
        public void Update(Role role);
        public ICollection<Role> GetAll();
        public void Save();
    }
}
