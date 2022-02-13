using System.Collections.Generic;

namespace Biblioteka.Core
{
    public interface IUserRepository
    {
        public void Add(User user);
        public void Update(User user);
        public ICollection<User> GetAll();
        public void Save();
    }
}
