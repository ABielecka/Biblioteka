using AutoMapper;
using Biblioteka.Core;
using Biblioteka.Core.DTOs.RentalDTOs;

namespace Biblioteka.View
{
    public class RentalMappingProfile : Profile
    {
        public RentalMappingProfile()
        {
            CreateMap<Rental, RentalDTO>();

            CreateMap<AddRentalDTO, Rental>()
                .ForMember(c => c.RentalDate, k => k.MapFrom(dto => dto.RentalDate))
                .ForMember(c => c.ReturnDate, k => k.MapFrom(dto => dto.RentalDate.AddDays(31)));

            CreateMap<ReturnDTO, Rental>();
        }
    }
}
