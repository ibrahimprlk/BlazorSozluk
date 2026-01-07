using System.Security.Cryptography;
using System.Text;

namespace BlozorSozluk.Common.Infrastructure
{
    public class PasswordEncryptor
    {
        public static string Encrpt(string password)
        {
            using var md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(password); // gelen sifrenin byte array'e cevrilmesi islemi
            byte[] hashBytes = md5.ComputeHash(inputBytes); // sifreyi sifrelenmis data'ya ceviriyoruz

            return Convert.ToHexString(hashBytes);
        }
    }
}
