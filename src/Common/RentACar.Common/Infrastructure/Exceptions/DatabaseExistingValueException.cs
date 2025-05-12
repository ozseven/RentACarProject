using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Infrastructure.Exceptions
{
    public class DatabaseExistingValueException : Exception
    {
        public DatabaseExistingValueException()
        {
        }

        public DatabaseExistingValueException(string? message) : base(message)
        {
        }

        public DatabaseExistingValueException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DatabaseExistingValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
