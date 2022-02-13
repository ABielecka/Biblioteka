using System;

namespace Biblioteka.Core
{
    public class CredentialsInvalidException : Exception
    {
        public CredentialsInvalidException(string message) : base(message)
        {

        }
    }
}
