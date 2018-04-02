using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public static string ip = "192.168.202.102";
        public static int port = 777;

        static void Main(string[] args)
        {
            

            try
            {
                TcpListener server = new TcpListener(IPAddress.Parse(ip), port);
                
                server.Start();

                Console.WriteLine("Сервер запущен");

                while (true)
                {
                    Console.WriteLine("Ожидание подключения");
                    
                    TcpClient client = server.AcceptTcpClient();

                    Console.WriteLine("Соединение установленно");
                    
                    NetworkStream stream = client.GetStream();
                    
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine("Здарова");
                    writer.Flush();

                    
                    client.Close();
                }
            }
            catch
            {

            }
        }

    }
}
