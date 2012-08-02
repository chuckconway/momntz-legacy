using System.Text;
using Chucksoft.Core.Cryptography;

namespace Momntz.Infrastructure.Security
{
    public class Crypto : ICrypto
    {
       public string Hash(string password)
       {
           byte[] salt = Encoding.Default.GetBytes("secretSalt");
           return SimpleHash.ComputeHash(password, SimpleHash.Algorithm.SHA384, salt);
       }

        public bool IsMatch(string password, string hashedPassword)
        {
          return  SimpleHash.VerifyHash(password, SimpleHash.Algorithm.SHA384, hashedPassword);
        }
    }
}
