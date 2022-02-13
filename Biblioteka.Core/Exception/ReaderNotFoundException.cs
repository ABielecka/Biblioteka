using System;

namespace Biblioteka.Core
{
    public class ReaderNotFoundException : Exception
    {
        public ReaderNotFoundException(string message) : base(message)
        {

        }
    }
}
