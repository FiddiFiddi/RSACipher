using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RSACipherH4
{
    public class Cipher
    {
        public byte[] EncryptData(byte[] data)
        {
            byte[] cipher;
            CspParameters csp = new CspParameters(1);
            csp.KeyContainerName = "KeyContainer";
            using (var rsa = new RSACryptoServiceProvider(2048, csp))
            {
                Console.WriteLine($"{rsa.ToXmlString(true)}");
                cipher = rsa.Encrypt(data, false);
            }
            return cipher;
        }

        public byte[] DecryptData(byte[] data)
        {
            byte[] plain;
            CspParameters csp = new CspParameters(1);
            csp.KeyContainerName = "KeyContainer";
            using (var rsa = new RSACryptoServiceProvider(2048, csp))
            {
                rsa.PersistKeyInCsp = false;
                plain = rsa.Decrypt(data, false);
            }
            return plain;
        }
    }
}
