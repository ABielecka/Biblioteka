using System.Collections.Generic;

namespace Biblioteka.Core
{
    public interface IReaderRepository
    {
        public void Add(Reader reader);
        public void Update(Reader reader);
        public ICollection<Reader> GetAll();
        public Reader GetReader(int index);
        public void Save();
    }
}
