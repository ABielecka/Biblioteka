using System;

namespace Biblioteka.Core.DTOs.RentalDTOs
{
    public class ReturnDTO
    {
        public DateTime ReturnDate { get; set; }
        public int BookIndex { get; set; }
        public int ReaderIndex { get; set; }
    }
}
