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

            Console.InputEncoding = Encoding.ASCII;
            string input = Console.ReadLine();
            byte[] encryptedData = cipher.EncryptData(Encoding.ASCII.GetBytes(input));
            Console.WriteLine($"{Convert.ToBase64String(encryptedData)}");

            byte[] decryptedData = cipher.DecryptData(encryptedData);
            Console.WriteLine($"DecryptedText: {Encoding.ASCII.GetString(decryptedData)}");
            SocketClient.StartTCPClient(encryptedData);

            Console.ReadLine();
            Console.WriteLine("Deleting Contained Key...");
            keyManager.DeleteKeyInCsp();

        }
    }
}
