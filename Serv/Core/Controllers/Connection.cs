using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Serv.Core.Controllers
{
    class Connection
    {

        public void Listener()
        {
            try
            {
                TcpListener server = new TcpListener(IPAddress.Parse(Configuration.Ip), Configuration.Port);

                server.Start();

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Models.Client cle = new Models.Client(client);
                    Data.Data.Clients.Add(cle);
                    Task task = Task.Run(() =>
                    cle.ConnectionClient()
                    );
                }
            }
            catch
            {

            }
        }

    }
}

