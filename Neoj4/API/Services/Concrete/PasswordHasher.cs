﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Neoj4.API.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Neoj4.API.Services.Concrete
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            var salt = GenerateSalt(16);
            var bytes = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);

            return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(bytes)}";
        }
        public bool CheckMatch(string password, string hashedPassword)
        {
            try
            {
                var parts = hashedPassword.Split(':');
                var salt = Convert.FromBase64String(parts[0]);
                var bytes = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA512, 10000, 16);

                return parts[1].Equals(Convert.ToBase64String(bytes));
            }
            catch
            {
                return false;
            }
        }
        private static byte[] GenerateSalt(int length)
        {
            var salt = new byte[length];
            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            return salt;
        }
    }
}
