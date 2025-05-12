using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Infrastructure.Exceptions
{
    public class DatabaseNotFoundValueException : Exception  // Veritabanında bulunamayan değer için özel hata
    {
        public DatabaseNotFoundValueException()
        {
        }

        public DatabaseNotFoundValueException(string? message) : base(message)  // Mesaj ile hata
        {
        }

        public DatabaseNotFoundValueException(string? message, Exception? innerException) : base(message, innerException)  // İç hata ile birlikte
        {
        }

        protected DatabaseNotFoundValueException(SerializationInfo info, StreamingContext context) : base(info, context)  // Serileştirme için
        {
        }
    }
}
