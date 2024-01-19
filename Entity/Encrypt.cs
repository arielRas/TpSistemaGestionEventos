using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Entity
{
    public class Encrypt
    {
        public byte[] GenerateSalt() 
        {
            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var randomNumber = new byte[32];

                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        private byte[] CombineBytes(byte[] password, byte[] salt)
        {
            var combinedBytes = new byte[password.Length + salt.Length];

            Buffer.BlockCopy(password, 0, combinedBytes, 0, password.Length);

            Buffer.BlockCopy(salt, 0, combinedBytes, password.Length, salt.Length);

            return combinedBytes;
        }

        public byte[] GethashedPassword(string password, byte[] salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordToByte = Encoding.UTF8.GetBytes(password);

                byte[] conbinedPassword = this.CombineBytes(passwordToByte, salt);

                return sha256.ComputeHash(conbinedPassword);
            }
        }
    }
}
