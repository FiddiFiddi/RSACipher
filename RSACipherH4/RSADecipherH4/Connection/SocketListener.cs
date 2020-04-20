using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RSADecipherH4.Connection
{
    public class SocketListener
    {
        public static void StartServer()
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 420);

            try
            {
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                listener.Bind(localEndPoint);
                listener.Listen(10);
                Socket handler = listener.Accept();
                string data = null;
                byte[] bytes = null;
                while (true)
                {
                    bytes = new byte[4096];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    var dataBytes = Encoding.ASCII.GetBytes(data);
                    Cipher cipher = new Cipher();
                    var message = cipher.DecryptData(dataBytes);
                    if (message != null)
                    {
                        break;
                    }
                }


                Console.WriteLine($"RECIEVED DATA: {data}");

                byte[] msg = Encoding.ASCII.GetBytes(data);
                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.ToString()}");
            }
        }

        public static void StartTCPServer()
        {
            IPAddress localAdd = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(localAdd, 420);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                string dataRecieved = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Recieved Data: {dataRecieved}");

                client.Close();
            }
            listener.Stop();
            // Convert string to byte array and decipher it.
        }
    }
}
