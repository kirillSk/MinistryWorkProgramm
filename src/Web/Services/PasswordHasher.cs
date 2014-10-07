using System.Security.Cryptography;
using System.Text;

namespace Web.Services
{
    public static class PasswordHasher
    {
        public static string Get(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var sha1data = new SHA1CryptoServiceProvider().ComputeHash(data);

            return Encoding.ASCII.GetString(sha1data);
        }
    }
}