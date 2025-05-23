﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Infrastructure.PasswordEncryptor
{
    public class PasswordEncryptor  // Şifreleme işlemleri için yardımcı sınıf
    {
        public static string Encrypt(string password)  // Şifreyi MD5 ile şifrele
        {
            using var md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);  // Şifrelenmiş değeri döndür
        }
    }
}
