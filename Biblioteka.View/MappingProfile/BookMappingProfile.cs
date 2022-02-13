using AutoMapper;
using Biblioteka.Core;

namespace Biblioteka.View
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(c => c.Type, k => k.MapFrom(s => s.BookType.Type))
                .ForMember(c => c.FirstName, k => k.MapFrom(s => s.Author.FirstName))
                .ForMember(c => c.LastName, k => k.MapFrom(s => s.Author.LastName));

            CreateMap<AddBookDTO, Book>()
                .ForMember(c => c.BookType, k => k.MapFrom(dto => new BookType() { Type = dto.Type }))
                .ForMember(c => c.Author,
                    k => k.MapFrom(dto => new Author()
                    { FirstName = dto.FirstName, LastName = dto.LastName, Country = new Country() { Name = dto.CountryName } }));
        }
    }
}
