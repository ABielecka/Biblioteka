using System.Collections.Generic;

namespace Biblioteka.Core
{
    public interface IRentalRepository
    {
        public void Add(Rental rental);
        public void Update(Rental rental);
        public ICollection<Rental> GetAll();
        public ICollection<Rental> Get(int index);
        public void Save();
    }
}
