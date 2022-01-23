using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Networking_Test_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        connection:
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 1333);
            senddata:
                string messageToSend = Console.ReadLine();
                int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);
                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);

                NetworkStream stream = client.GetStream(); //opens memory slot for the stream data
                stream.Write(sendData, 0, sendData.Length); //writes the bytes from 0 to end
                Console.WriteLine("Pass: Sent");

                StreamReader sr = new StreamReader(stream);
                string response = sr.ReadLine();
                Console.WriteLine(response);
                string msg = Console.ReadLine();
                if (msg == "")
                {

                    goto close;
                }
                goto senddata;

            close:
                stream.Close();
                client.Close();
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine("failed to connect...");
                goto connection; //retries connection if failed
            }
        }
    }
}
