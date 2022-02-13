using AutoMapper;
using Biblioteka.Core;

namespace Biblioteka.View
{
    public class ReaderMappingProfile : Profile
    {
        public ReaderMappingProfile()
        {
            CreateMap<Reader, ReaderDTO>();

            CreateMap<AddReaderDTO, Reader>()
                .ForMember(c => c.Address,
                    k => k.MapFrom(dto => new Address()
                        {City = dto.City, Street = dto.Street, Number = dto.Number, PostalCode = dto.PostalCode}));

            //CreateMap<Rental, RentalDTO>()
            //    .ForMember(c => c.Book, k => k.MapFrom(s => s.Book))
            //    .ForMember(c => c.RentalDate, k => k.MapFrom(s => s.RentalDate))
            //    .ForMember(c => c.Overdue, k => k.MapFrom(s => s.Overdue));
        }
    }
}