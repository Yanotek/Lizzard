using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Serv.Core.Commands.RDP
{
    [DataContract]
    class RemoteScreenCommand : ICommand
    {
        [DataMember]
        public int Id { get; set; } = 2;
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }

        public string Serialize()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(this);
        }
    }
}
