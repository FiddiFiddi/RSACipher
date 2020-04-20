using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RSACipherH4.Connection
{
    public class SocketClient
    {


        public static void StartClient(byte[] msg)
        {
            var bytes = new byte[4096];
            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 420);
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(remoteEP);
                var bytesSent = sender.Send(msg);
                var bytesRec = sender.Receive(bytes);

                Console.WriteLine($"RESPONSE: {Encoding.ASCII.GetString(bytes, 0, bytesRec)}");

                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.ToString()}");
            }
        }

        public static void StartTCPClient(string textToSend)
        {

        }

    }
}
