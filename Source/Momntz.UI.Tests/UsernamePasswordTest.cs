using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chucksoft.Core.Cryptography;
using NUnit.Framework;

namespace Momntz.UI.Tests
{
    [TestFixture]
    public class UsernamePasswordTest
    {
        [Test]
        public void Password_CreatePassword_HashIsComparable()
        {
            string superSecretSalt = "SecretSalt";

            byte[] salt = Encoding.Default.GetBytes(superSecretSalt);
            string hash = SimpleHash.ComputeHash("Password", SimpleHash.Algorithm.SHA384, salt);

            bool var = SimpleHash.VerifyHash("Password", SimpleHash.Algorithm.SHA384, hash);
        }
    }
}
