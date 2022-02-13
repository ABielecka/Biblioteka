using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteka.Core
{
    public interface IReaderServices
    {
        ICollection<ReaderDTO> GetAll();
        bool Add(AddReaderDTO dto);
    }

    public class ReaderServices : IReaderServices
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IMapper _mapper;

        public ReaderServices(IReaderRepository readerRepository, IMapper mapper)
        {
            _readerRepository = readerRepository;
            _mapper = mapper;
        }

        public ICollection<ReaderDTO> GetAll()
        {
            return null;
        }

        public bool Add(AddReaderDTO dto)
        {
            var reader = _mapper.Map<Reader>(dto);
            var readerCheck = _readerRepository.GetAll()
                .FirstOrDefault(c => c.ReaderIndexNumber == dto.ReaderIndexNumber);

            if (readerCheck != null) throw new ReaderExistsException("Reader already exists");

            _readerRepository.Add(reader);
            _readerRepository.Save();

            return true;
        }
    }
}
