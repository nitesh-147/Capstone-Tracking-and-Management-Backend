using System.Security.Cryptography;

namespace TrackingApp.Helper
{
    public class PasswordHasher
    {
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        public static readonly int SaltSize = 16;
        public static readonly int HashSize = 20;
        public static readonly int Iterations = 10000;

        public static string HashPassword(string password)
        {
            byte[] salt;
            rng.GetBytes(salt = new byte[SaltSize]);
            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = key.GetBytes(HashSize);
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            var base64hash = Convert.ToBase64String(hashBytes);

            return base64hash;
        }

        public static bool VerifyPassword(string password, string base64hash)
        {
            var hashBytes = Convert.FromBase64String(base64hash);
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);
            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = key.GetBytes(HashSize);
            for (var i = 0; i < HashSize; i++)
            {
                if (hash[i] != hashBytes[i + SaltSize])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
