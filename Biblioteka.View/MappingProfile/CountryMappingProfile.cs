using AutoMapper;
using Biblioteka.Core;

namespace Biblioteka.View
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Country, CountryDTO>();
            CreateMap<AddCountryDTO, Country>()
                .ForMember(c => c.Name, k => k.MapFrom(dto => dto.Name));
            CreateMap<UpdateCountryDTO, Country>();
        }
    }
}
