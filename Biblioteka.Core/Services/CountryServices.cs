using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.Core
{
    public interface ICountryServices
    {
        ICollection<CountryDTO> GetAll();
        bool Add(AddCountryDTO dto);
        bool Update(string name, UpdateCountryDTO dto);
    }

    public class CountryServices : ICountryServices
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryServices(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public ICollection<CountryDTO> GetAll()
        {
            var countries = _countryRepository.GetAll();
            var countriesDTO = _mapper.Map<List<CountryDTO>>(countries);
            return countriesDTO;
        }

        public bool Add(AddCountryDTO dto)
        {
            var country = _mapper.Map<Country>(dto);
            var countryCheck = _countryRepository.GetAll().FirstOrDefault(c => c.Name.ToUpper().Equals(dto.Name.ToUpper()));

            if (countryCheck is null)
            {
                _countryRepository.Add(country);
                _countryRepository.Save();
                return true;
            }
            else
            {
                throw new Exception("Państwo o takiej nazwie już istnieje.");
            }
            
        }

        public bool Update(string name, UpdateCountryDTO dto)
        {
            var country = _countryRepository.GetAll().FirstOrDefault(c => c.Name == name);

            if (country is null) return false;

            country.Name = dto.Name;
            _countryRepository.Save();

            return true;
        }
    }
}
