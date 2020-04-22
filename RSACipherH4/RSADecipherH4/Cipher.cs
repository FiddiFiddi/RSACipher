using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RSADecipherH4
{
    public class Cipher
    {
        public byte[] EncryptData(byte[] data)
        {
            byte[] cipher;
            CspParameters csp = new CspParameters();
            csp.KeyContainerName = "KeyContainer";
            using (var rsa = new RSACryptoServiceProvider(2048, csp))
            {
                cipher = rsa.Encrypt(data, false);
            }
            return cipher;
        }

        public byte[] DecryptData(byte[] data)
        {
            byte[] plain;
            CspParameters csp = new CspParameters();
            csp.KeyContainerName = "KeyContainer";
            using (var rsa = new RSACryptoServiceProvider(2048, csp))
            {
                plain = rsa.Decrypt(data, false);
            }
            return plain;
        }
    }
}
