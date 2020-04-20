using RSACipherH4.Connection;
using System;
using System.Security.Cryptography;
using System.Text;

namespace RSACipherH4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I AM A CLIENT");
            // Create a new Container for the key in microsoft store
            KeyManager keyManager = new KeyManager();
            Console.WriteLine("Creating Contained Key...");
            keyManager.AssignNewKey();

            Cipher cipher = new Cipher();

            Console.WriteLine("Welcome to RSA Communication");

            Console.WriteLine("Input text to reciever");

            var input = Console.ReadLine();
            var encryptedData = cipher.EncryptData(Encoding.UTF8.GetBytes(input));
            Console.WriteLine($"{Convert.ToBase64String(encryptedData)}");

            var decryptedText = cipher.DecryptData(encryptedData);
            Console.WriteLine($"DecryptedText: {Encoding.UTF8.GetString(decryptedText)}");
            SocketClient.StartClient(encryptedData);

            Console.ReadLine();
            Console.WriteLine("Deleting Contained Key...");
            keyManager.DeleteKeyInCsp();

        }
    }
}
