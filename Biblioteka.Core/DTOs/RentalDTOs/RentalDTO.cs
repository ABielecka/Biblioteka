using System;

namespace Biblioteka.Core
{
    public class RentalDTO
    {
        public DateTime RentalDate { get; set; }
        public int BookIndex { get; set; }
        public int ReaderIndex { get; set; }
    }
}
