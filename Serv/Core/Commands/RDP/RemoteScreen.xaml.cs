using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Serv.Core.Commands.RDP
{
    /// <summary>
    /// Логика взаимодействия для RemoteScreen.xaml
    /// </summary>
    public partial class RemoteScreen : Window
    {
        public RemoteScreen(string ConnectionString, string UserName, string Password)
        {
            InitializeComponent();
            RDPViewer.Connect(ConnectionString, UserName, Password);
            WindowState = WindowState.Maximized;
            RDPViewer.SmartSizing = true;
        }
    }
}
