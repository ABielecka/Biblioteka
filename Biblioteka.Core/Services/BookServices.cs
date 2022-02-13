using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Biblioteka.Core.Services
{
    public interface IBookServices
    {
        ICollection<BookDTO> GetBooks(string Title);
        bool Add(AddBookDTO dto);
        public void Remove(int index);
    }

    public class BookServices : IBookServices
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookTypeRepository _bookTypeRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public BookServices(IBookRepository bookRepository, IAuthorRepository authorRepository, IBookTypeRepository bookTypeRepository, ICountryRepository countryRepository, IRentalRepository rentalRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _bookTypeRepository = bookTypeRepository;
            _countryRepository = countryRepository;
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public ICollection<BookDTO> GetBooks(string Title)
        {
            var bookss = _bookRepository.GetAll();
            var books = _bookRepository.GetAll().Where(c => c.Title.ToUpper().Equals(Title.ToUpper()) && c.Status != false);
            var booksDTO = _mapper.Map<List<BookDTO>>(books);

            foreach (var b in booksDTO.Where(c => c.isReturned == false))
            {
                var lastRental = _rentalRepository.Get(b.BookIndexNumber).OrderByDescending(c => c.RentalDate).FirstOrDefault(c => c.IsReturned == false);
                b.ReturnDate = lastRental.ReturnDate;
            }
            return booksDTO;
        }

        public bool Add(AddBookDTO dto)
        {
            
            var book = _mapper.Map<Book>(dto);
            var bookType = _bookTypeRepository.GetAll().FirstOrDefault(c => c.Type.ToUpper().Equals(dto.Type.ToUpper()));
            var country = _countryRepository.GetCountry(dto.CountryName);
            var author = _authorRepository.GetAuthor(dto.FirstName, dto.LastName, dto.CountryName);

            if (country != null)
            {
                if (author != null)
                {
                    book.Author = author;
                }
                else
                {
                    book.Author.Country = country;
                }
            }

            if (bookType != null)
            {
                book.BookType = bookType;
            }

            book.Status = true;
            _bookRepository.Add(book);
            _bookRepository.Save();
            return true;
        }

        public void Remove(int index)
        {
            var book = _bookRepository.GetBook(index);

            //_bookRepository.Remove(book);
            book.Status = false;
            _bookRepository.Save();
        }
    }
}
