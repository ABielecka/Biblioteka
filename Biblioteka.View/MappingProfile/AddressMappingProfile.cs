using AutoMapper;
using Biblioteka.Core;

namespace Biblioteka.View
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<Address, AddressDTO>();
            CreateMap<AddAddressDTO, Address>()
                .ForMember(c => c.City, k => k.MapFrom(dto => dto.City))
                .ForMember(c => c.Street, k => k.MapFrom(dto => dto.Street))
                .ForMember(c => c.Number, k => k.MapFrom(dto => dto.Number))
                .ForMember(c => c.PostalCode, k => k.MapFrom(dto => dto.PostalCode));
            CreateMap<UpdateAddressDTO, Address>();
        }
    }
}
