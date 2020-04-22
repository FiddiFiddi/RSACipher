using RSADecipherH4.Connection;
using System;

namespace RSADecipherH4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I AM A RECIEVER");
            Console.WriteLine("Welcome to RSA Communication");
            SocketListener.StartTCPServer();
            Console.ReadLine();
        }
    }
}
