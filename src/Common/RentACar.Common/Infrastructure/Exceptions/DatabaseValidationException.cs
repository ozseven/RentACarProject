using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Infrastructure.Exceptions
{
    public class DatabaseValidationException : Exception  // Veritabanı doğrulama hatası için özel exception
    {
        public DatabaseValidationException()
        {
        }

        public DatabaseValidationException(string? message) : base(message)  // Mesaj ile hata
        {
        }

        public DatabaseValidationException(string? message, Exception? innerException) : base(message, innerException)  // İç hata ile birlikte
        {
        }

        protected DatabaseValidationException(SerializationInfo info, StreamingContext context) : base(info, context)  // Serileştirme için
        {
        }
    }
}
