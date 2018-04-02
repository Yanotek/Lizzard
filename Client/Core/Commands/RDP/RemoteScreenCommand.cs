using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Client.Core.Commands.RDP
{
    [DataContract]
    public class RemoteScreenCommand
    {
        [DataMember]
        public int Id { get; set; } = 2;
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }

    }
}
