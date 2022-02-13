using AutoMapper;
using Biblioteka.Core;

namespace Biblioteka.View.MappingProfile
{
    public class BookTypeMappingProfile : Profile
    {
        public BookTypeMappingProfile()
        {
            CreateMap<BookType, BookTypeDTO>();
            CreateMap<AddBookTypeDTO, BookType>()
                .ForMember(c => c.Type, k => k.MapFrom(dto => dto.Type));
            CreateMap<UpdateBookTypeDTO, BookType>();
        }
    }
}
