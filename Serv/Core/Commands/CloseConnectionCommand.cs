using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Serv.Core.Commands
{
    class CloseConnectionCommand : ICommand
    {
        public int Id { get; set; } = 3;

        public string Serialize()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(this);
        }
    }
}
