using System;

namespace PayU.Exceptions
{
    public class InvalidAuthException : Exception
    {
        public InvalidAuthException()
        {
        }

        public InvalidAuthException(string message) : base(message)
        {
        }

        public InvalidAuthException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}