using System;

namespace Biblioteka.Core
{
    public class ReaderExistsException : Exception
    {
        public ReaderExistsException(string message) : base(message)
        {

        }
    }
}
