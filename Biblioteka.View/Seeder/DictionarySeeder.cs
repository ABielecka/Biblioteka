using Biblioteka.Core;
using System.Collections.Generic;

namespace Biblioteka.View
{
    public class DictionarySeeder
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IBookTypeRepository _bookTypeRepository;

        public DictionarySeeder(IRoleRepository roleRepository,
                                ICountryRepository countryRepository,
                                IBookTypeRepository bookTypeRepository)
        {
            _roleRepository = roleRepository;
            _countryRepository = countryRepository;
            _bookTypeRepository = bookTypeRepository;
        }

        public void Seed()
        {
            var bookTypes = _bookTypeRepository.GetAll();
            if (!(bookTypes != null && bookTypes.Count > 0))
            {
                var newType = GetBookTypes();

                foreach (var b in newType)
                {
                    _bookTypeRepository.Add(b);
                }
                _bookTypeRepository.Save();
            }

            var countries = _countryRepository.GetAll();
            if (!(countries != null && countries.Count > 0))
            {
                var newCountry = GetCountries();

                foreach (var c in newCountry)
                {
                    _countryRepository.Add(c);
                }
                _roleRepository.Save();
            }

            var roles = _roleRepository.GetAll();
            if (!(roles != null && roles.Count > 0))
            {
                var newRole = GetRoles();

                foreach (var r in newRole)
                {
                    _roleRepository.Add(r);
                }
                _roleRepository.Save();
            }
        }//kontroler dla czytelników i endpoint dla listy czytelików (ReaderDTO)


        private IEnumerable<Country> GetCountries()
        {
            var counties = new List<Country>()
            {
                new Country()
                {
                    Name = "Poland"
                },
                new Country()
                {
                    Name = "Germany"
                },
                new Country()
                {
                    Name = "France"
                }
            };
            return counties;
        }

        private IEnumerable<BookType> GetBookTypes()
        {
            var bookTypes = new List<BookType>()
            {
                new BookType()
                {
                    Type = "Poetry"
                },
                new BookType()
                {
                    Type = "Dictionary"
                },
                new BookType()
                {
                    Type = "Science-fiction"
                }
            };
            return bookTypes;
        }

        private IEnumerable<Role> GetRoles()
        {
            var role = new List<Role>()
            {
                new Role()
                {
                    Name = "Admin"
                },
                new Role()
                {
                    Name = "Librarian"
                }
            };
            return role;
        }
    }
}
