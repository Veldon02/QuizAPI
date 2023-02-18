using Application.Common.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public class Hasher: IHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 20;

        public string Hash(string password, int iterations)
        {

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt;
                rng.GetBytes(salt = new byte[SaltSize]);
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                {
                    var hash = pbkdf2.GetBytes(HashSize);

                    var hashBytes = new byte[SaltSize + HashSize];
                    Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                    Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

                    var base64Hash = Convert.ToBase64String(hashBytes);

                    return $"$HASH|V1${iterations}${base64Hash}";
                }
            }

        }
        public string Hash(string password)
        {
            return Hash(password, 10000);
        }

        public bool Verify(string password, string hashedPassword)
        {

            var splittedHashString = hashedPassword.Replace("$HASH|V1$", "").Split('$');
            var iterations = int.Parse(splittedHashString[0]);
            var base64Hash = splittedHashString[1];

            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                for (var i = 0; i < HashSize; i++)
                {
                    if (hashBytes[i + SaltSize] != hash[i])
                    {
                        return false;
                    }
                }

                return true;
            }

        }
    }
}
