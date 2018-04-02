using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;

namespace Serv.Core.Commands.ShowMessageBox
{
    [DataContract]
    public class ShowMessageBox : ICommand
    {
        [DataMember]
        public int Id { get; set; } = 1;
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string Header { get; set; }
        [DataMember]
        public MessageBoxButton Buttons { get; set; }
        [DataMember]
        public MessageBoxImage Image { get; set; }

        public string Serialize()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(this);
        }
    }
}
