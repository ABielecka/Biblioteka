using AutoMapper;
using System;
using System.Linq;

namespace Biblioteka.Core
{
    public interface IAddressServices
    {
        bool Add(AddAddressDTO dto);
        bool Update(string City, string Street, int Number, string PostalCode, UpdateAddressDTO dto);
    }

    public class AddressServices : IAddressServices
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressServices(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public bool Add(AddAddressDTO dto)
        {
            var address = _mapper.Map<Address>(dto);
            var addressCheck = _addressRepository.GetAll()
                .FirstOrDefault(c => c.City.ToUpper().Equals(dto.City.ToUpper())
                                  && c.Street.ToUpper().Equals(dto.Street.ToUpper())
                                  && c.Number == dto.Number
                                  && c.PostalCode.ToUpper().Equals(dto.PostalCode.ToUpper()));

            if (addressCheck is null)
            {
                _addressRepository.Add(address);
                _addressRepository.Save();
                return true;
            }
            else
            {
                throw new Exception("Address already exist.");
            }
        }

        public bool Update(string City, string Street, int Number, string PostalCode, UpdateAddressDTO dto)
        {
            var address = _addressRepository.GetAll().FirstOrDefault(c => c.City == City
                                                                          && c.Street == Street
                                                                          && c.Number == Number
                                                                          && c.PostalCode == PostalCode);
            if (address is null) return false;

            address.City = dto.City;
            address.Street = dto.Street;
            address.Number = dto.Number;
            address.PostalCode = dto.PostalCode;

            _addressRepository.Save();
            return true;
        }
    }
}
