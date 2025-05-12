using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Infrastructure.Exceptions
{
    public class DatabaseNotFoundValueException : Exception
    {
        public DatabaseNotFoundValueException()
        {
        }

        public DatabaseNotFoundValueException(string? message) : base(message)
        {
        }

        public DatabaseNotFoundValueException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DatabaseNotFoundValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
