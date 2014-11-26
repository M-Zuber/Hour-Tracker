using System;
using System.Runtime.Serialization;

namespace Backend.Exceptions
{
    /// <summary>
    /// This is exception is thrown when any invalid time punch is performed
    /// </summary>
    public class InvalidTimePunchException : Exception
    {
        public InvalidTimePunchException()
        {
        }

        public InvalidTimePunchException(string message)
            : base(message)
        {
        }

        public InvalidTimePunchException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}