﻿using System;
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


            bool notconnected = true;
            //while (notconnected)
            //{
               // try
                //{
                    TcpClient client = new TcpClient("127.0.0.1", 1333);
                    NetworkStream stream = client.GetStream();
                    notconnected = false;
                //}
               // catch (Exception e)
               // {
               ///     Console.WriteLine("Couldn't connect");
               // }
           // }

            send(50, 100, client, stream);
            close(client, stream);

            
            
            
            
            
            
            static void send(int a, int b, TcpClient client, NetworkStream stream)
            {
                byte[] x = new byte[4];
                x = BitConverter.GetBytes(50);
                byte[] y = new byte[4];
                y = BitConverter.GetBytes(100);

                byte[] msg = new byte[8];
                Buffer.BlockCopy(x, 0, msg, 0, 4);
                Buffer.BlockCopy(y, 0, msg, 4, 4);



                //opens memory slot for the stream data
                stream.Write(msg, 0, msg.Length); //writes the bytes from 0 to end
                Console.WriteLine("Pass: Sent");

            }
               
            
            static void close(TcpClient client, NetworkStream stream)
            {
                stream.Close();
                client.Close();
            }

                }
                
            }
            }
       // }
   // }

