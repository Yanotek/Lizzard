using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Serv.Core.Models
{
    public class Client
    {
        public string CompName { get; set; }
        public string UserName { get; set; }
        public TcpClient TcpClient;
        public StreamReader Reader;
        public StreamWriter Writer;
        public Client(TcpClient client)
        {
            TcpClient = client;
            Reader = new StreamReader(TcpClient.GetStream());
            Writer = new StreamWriter(TcpClient.GetStream());
        }

        public void ConnectionClient()
        {

            StreamReader reader = Reader;
            try
            {
                string s = reader.ReadLine();
                CompName = s.Split(';')[0];
                UserName = s.Split(';')[1];
            }
            catch
            {
                reader.Close();
                TcpClient.Close();
                Data.Data.Clients.Remove(this);
            }
        }

        public void SendMessage(string Message)
        {
            Writer.WriteLine(Message);
            Writer.Flush();
        }
    }
}
