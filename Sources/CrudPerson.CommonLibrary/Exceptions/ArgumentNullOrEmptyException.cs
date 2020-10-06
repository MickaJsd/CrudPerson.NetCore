using System;
using System.Runtime.Serialization;

namespace CrudPerson.CommonLibrary.Exceptions
{
    [Serializable]
    public class ArgumentNullOrEmptyException : ArgumentNullException
    {
        public ArgumentNullOrEmptyException()
        {
        }

        public ArgumentNullOrEmptyException(string paramName) : base(paramName)
        {
        }

        public ArgumentNullOrEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ArgumentNullOrEmptyException(string paramName, string message) : base(paramName, message)
        {
        }

        protected ArgumentNullOrEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
