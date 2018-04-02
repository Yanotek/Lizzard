using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Serv.Core.Commands.RDP
{
    public class Remote
    {
        private Models.Client client;

        public Remote(Models.Client client)
        {
            this.client = client;
        }

        public void Connection()
        {
            RemoteScreenCommand command = new RemoteScreenCommand
            {
                Password = "Value",
                UserName = "Value"
            };
            client.SendMessage(command.Serialize());
            string connectionString = client.Reader.ReadLine();
            RemoteScreen screen = new RemoteScreen(connectionString, command.Password, command.UserName);
            screen.Show();
        }
    }
}
