using System.Collections.Generic;

namespace Biblioteka.Core
{
    public interface ICountryRepository
    {
        public void Add(Country country);
        public ICollection<Country> GetAll();
        public Country GetCountry(string CountryName);
        public void Update(Country country);
        public void Save();
    }
}
