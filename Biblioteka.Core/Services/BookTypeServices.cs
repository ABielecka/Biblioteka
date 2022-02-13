using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.Core.Services
{

    public interface IBookTypeServices
    {
        ICollection<BookTypeDTO> GetAll();
        bool Add(AddBookTypeDTO dto);
        bool Update(string Type, UpdateBookTypeDTO dto);
    }

    public class BookTypeServices : IBookTypeServices
    {
        private readonly IBookTypeRepository _bookTypeRepository;
        private readonly IMapper _mapper;

        public BookTypeServices(IBookTypeRepository bookTypeRepository, IMapper mapper)
        {
            _bookTypeRepository = bookTypeRepository;
            _mapper = mapper;
        }

        public ICollection<BookTypeDTO> GetAll()
        {
            var bookTypes = _bookTypeRepository.GetAll();
            var bookTypesDTO = _mapper.Map<List<BookTypeDTO>>(bookTypes);
            return bookTypesDTO;
        }

        public bool Add(AddBookTypeDTO dto)
        {
            var bookType = _mapper.Map<BookType>(dto);
            var bookTypeCheck = _bookTypeRepository.GetAll()
                .FirstOrDefault(c => c.Type.ToUpper().Equals(dto.Type.ToUpper()));

            if (bookTypeCheck is null)
            {
                _bookTypeRepository.Add(bookType);
                _bookTypeRepository.Save();
                return true;
            }
            else
            {
                throw new Exception("Book type already exists.");
            }
        }

        public bool Update(string Type, UpdateBookTypeDTO dto)
        {
            var bookType = _bookTypeRepository.GetAll().FirstOrDefault(c => c.Type == Type);

            if (bookType is null) return false;

            bookType.Type = dto.Type;
            _bookTypeRepository.Save();

            return true;
        }
    }
}
