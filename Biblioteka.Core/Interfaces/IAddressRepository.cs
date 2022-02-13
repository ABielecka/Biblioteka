using System.Collections.Generic;

namespace Biblioteka.Core
{
    public interface IAddressRepository
    {
        void Add(Address address);
        void Update(Address address);
        ICollection<Address> GetAll();
        void Save();
    }
}
