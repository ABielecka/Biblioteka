using AutoMapper;
using Biblioteka.Core.DTOs.RentalDTOs;
using System;
using System.Linq;

namespace Biblioteka.Core.Services
{
    public interface IRentalServices
    {
        Rental Add(AddRentalDTO dto);
        void Return(ReturnDTO dto);
    }

    public class RentalServices : IRentalServices
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IReaderRepository _readerRepository;
        private readonly IMapper _mapper;

        public RentalServices(IRentalRepository rentalRepository, IBookRepository bookRepository, IReaderRepository readerRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
            _mapper = mapper;
        }

        public Rental Add(AddRentalDTO dto)
        {
            var rental = _mapper.Map<Rental>(dto);

            var book = _bookRepository.GetBook(dto.BookIndex);
            var reader = _readerRepository.GetReader(dto.ReaderIndex);

            if (book is null || book.isReturned == false) throw new BookNotFoundException("Book not found or is not available.");
            if (reader is null) throw new ReaderNotFoundException("Reader not found or has too many books.");

            rental.Book = book;
            rental.Reader = reader;

            book.isReturned = false;
            reader.NumberOfBooks += 1;

            _rentalRepository.Add(rental);
            _rentalRepository.Save();
            return rental;
        }

        public void Return(ReturnDTO dto)
        {
            var book = _bookRepository.GetBook(dto.BookIndex);

            book.isReturned = true;

            var rental = _rentalRepository.GetAll().OrderByDescending(c => c.ReturnDate).FirstOrDefault(c => c.Book.BookIndexNumber == dto.BookIndex && c.Reader.ReaderIndexNumber == dto.ReaderIndex);
            if (rental is null) throw new RentalNotFound("Rental does not exists.");

            rental.IsReturned = true;
            rental.Overdue = (long)(DateTime.Now - rental.ReturnDate).TotalDays;

            if (rental.Overdue > 0)
            {
                rental.Fine = rental.Overdue * 2;
            }

            rental.Reader.NumberOfBooks -= 1;
            _rentalRepository.Save();
        }
    }
}
