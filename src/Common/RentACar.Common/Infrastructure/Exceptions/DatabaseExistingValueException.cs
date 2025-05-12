using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Infrastructure.Exceptions
{
    public class DatabaseExistingValueException : Exception  // Veritabanında zaten var olan değer için özel hata
    {
        public DatabaseExistingValueException()
        {
        }

        public DatabaseExistingValueException(string? message) : base(message)  // Mesaj ile hata
        {
        }

        public DatabaseExistingValueException(string? message, Exception? innerException) : base(message, innerException)  // İç hata ile birlikte
        {
        }

        protected DatabaseExistingValueException(SerializationInfo info, StreamingContext context) : base(info, context)  // Serileştirme için
        {
        }
    }
}
