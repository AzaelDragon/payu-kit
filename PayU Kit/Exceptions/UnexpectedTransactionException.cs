using System;

namespace PayU.Exceptions
{
    public class UnexpectedTransactionException : Exception
    {
        public UnexpectedTransactionException()
        {
        }

        public UnexpectedTransactionException(string message) : base(message)
        {
        }

        public UnexpectedTransactionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}