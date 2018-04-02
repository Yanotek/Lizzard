using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Forms;

namespace Client.Core.Commands
{
    [DataContract]
    public class ShowMessageBox
    {
        [DataMember]
        public int Id { get; set; } = 1;
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string Header { get; set; }
        [DataMember]
        public MessageBoxButtons Buttons { get; set; }
        [DataMember]
        public MessageBoxIcon Image { get; set; }

        public void Show()
        {
            MessageBox.Show(Text, Header, Buttons, Image);
        }
    }
}
