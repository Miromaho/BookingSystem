using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookingSys
{
    internal class Hashing
    {
        public string Hash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
