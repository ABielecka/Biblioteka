using System;

namespace Biblioteka.Core
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(string message) : base(message)
        {

        }
    }
}
