using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace RSACipherH4
{
    public class KeyManager
    {
        private const string ContainerName = "KeyContainer";
        // Created a Key Manager class to handle key creation
        public void AssignNewKey()
        {
            CspParameters cspParams = new CspParameters(1);
            cspParams.KeyContainerName = ContainerName;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
            var rsa = new RSACryptoServiceProvider(cspParams);
            rsa.PersistKeyInCsp = true;
        }

        public void DeleteKeyInCsp()
        {
            var cspParams = new CspParameters();
            cspParams.KeyContainerName = ContainerName;
            var rsa = new RSACryptoServiceProvider(cspParams);
            rsa.PersistKeyInCsp = false;
            rsa.Clear();
        }
    }
}
