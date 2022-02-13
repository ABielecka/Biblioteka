using System;

namespace Biblioteka.Core
{
    public class RentalNotFound : Exception
    {
        public RentalNotFound(string message) : base(message)
        {

        }
    }
}
