using System;

namespace Biblioteka.Core
{
    public class AddRentalDTO
    {
        public DateTime RentalDate { get; set; }
        public int BookIndex { get; set; }
        public int ReaderIndex { get; set; }
    }
}
