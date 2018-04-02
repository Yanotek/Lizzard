using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Serv.Core.Models;

namespace Serv
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            Core.Controllers.Connection connection = new Core.Controllers.Connection();
            Task.Run(() =>  connection.Listener());
        }
    }

    public class MainWindowViewModel : Other.ViewModel
    {
        public MainWindowViewModel()
        {
            RefreshCommand = new Other.SimpleCommand(Refresh);
            SendMessageCommand = new Other.SimpleCommand(SendMessage);
            RemoteScreenCommand = new Other.SimpleCommand(RemoteScreen);
            CloseConnectionCommand = new Other.SimpleCommand(CloseConnection);
            Refresh();
        }

        public void RemoteScreen()
        {
            Core.Commands.RDP.Remote remote = new Core.Commands.RDP.Remote(SelectedClient);
            remote.Connection();


        }

        public void SendMessage()
        {
            Core.Commands.ShowMessageBox.ShowMessageWindow window = new Core.Commands.ShowMessageBox.ShowMessageWindow(SelectedClient);
            window.Show();
        }

        public void CloseConnection()
        {
            Core.Commands.CloseConnectionCommand close = new Core.Commands.CloseConnectionCommand();
            SelectedClient.SendMessage(close.Serialize());
            Core.Data.Data.Clients.Remove(SelectedClient);
        }

        public Client SelectedClient { get; set; }

        private ObservableCollection<Client> clients;

        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                OnPropertyChanged("Clients");
            }
        }
        public string MessageText { get; set; }

        public Other.SimpleCommand SendMessageCommand { get; set; }
        
        public Other.SimpleCommand RefreshCommand { get; set; }

        public Other.SimpleCommand RemoteScreenCommand { get; set; }

        public Other.SimpleCommand CloseConnectionCommand { get; set; }

        public void Refresh()
        {
            Clients = new ObservableCollection<Client>(Core.Data.Data.Clients);
        }
    }
}
