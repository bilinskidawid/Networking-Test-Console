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

            TcpClient client = null;
            NetworkStream stream = null;
            StreamReader sr = null;
            bool notconnected = true;
            while (notconnected)
            {
                System.Threading.Thread.Sleep(4000); //retries every 4 seconds
                try
                {
                    client = new TcpClient("127.0.0.1", 1333);
                    stream = client.GetStream();
                    sr = new StreamReader(stream);
                    notconnected = false; //if it does connect without throwing errors, it can exit the while loop and carry on with the program.
                }
                catch (Exception e)
                {
                    Console.WriteLine("Couldn't connect"); //will loop until connects
                }
            }


            send(50, 100, client, stream);
            send(51, 130, client, stream);
            send(20, 150, client, stream);
            close(client, stream);

            
            
            
            
            
            
            static void send(int a, int b, TcpClient client, NetworkStream stream)
            {
                byte[] x = new byte[4];
                x = BitConverter.GetBytes(a);
                byte[] y = new byte[4];
                y = BitConverter.GetBytes(b);

                byte[] msg = new byte[8];
                Buffer.BlockCopy(x, 0, msg, 0, 4);
                Buffer.BlockCopy(y, 0, msg, 4, 4);



                //opens memory slot for the stream data
                stream.Write(msg, 0, msg.Length); //writes the bytes from 0 to end
                Console.WriteLine("Pass: Sent");
                stream.Flush();
                
            }
               
            
            static void close(TcpClient client, NetworkStream stream)
            {
                stream.Close();
                client.Close();
            }

                }
                
            }
            }
      
