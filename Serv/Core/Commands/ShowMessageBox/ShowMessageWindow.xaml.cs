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
using System.Windows.Shapes;

namespace Serv.Core.Commands.ShowMessageBox
{
    /// <summary>
    /// Логика взаимодействия для ShowMessageWindow.xaml
    /// </summary>
    public partial class ShowMessageWindow : Window
    {
        public ShowMessageWindow(Models.Client client)
        {
            InitializeComponent();
            DataContext = new ShowMessageWindowViewModel(client);
        }
    }

    public class ShowMessageWindowViewModel : Other.ViewModel
    {

        public ShowMessageWindowViewModel(Models.Client client)
        {
            this.client = client;
            ShowCommand = new Other.SimpleCommand(Show);
            SendMessageBoxCommand = new Other.SimpleCommand(SendMessage);
            
        }

        Dictionary<string, MessageBoxButton> buttons = new Dictionary<string, MessageBoxButton>()
        {
            ["OK"] = MessageBoxButton.OK,
            ["OKCancel"] = MessageBoxButton.OKCancel,
            ["YesNo"] = MessageBoxButton.YesNo,
            ["YesNoCancel"] = MessageBoxButton.YesNoCancel
        };

        Dictionary<string, MessageBoxImage> images = new Dictionary<string, MessageBoxImage>()
        {
            ["Asterisk"] = MessageBoxImage.Asterisk,
            ["Error"] = MessageBoxImage.Error,
            ["Exclamation"] = MessageBoxImage.Exclamation,
            ["Hand"] = MessageBoxImage.Hand,
            ["Information"] = MessageBoxImage.Information,
            ["None"] = MessageBoxImage.None,
            ["Question"] = MessageBoxImage.Question,
            ["Stop"] = MessageBoxImage.Stop,
            ["Warning"] = MessageBoxImage.Warning,
        };

        public Models.Client client;

        public List<String> Buttons
        {
            get
            {
                return buttons.Select(x => x.Key).ToList();
            }
        }

        public List<String> Images
        {
            get
            {
                return images.Select(x => x.Key).ToList();
            }
        }

        public string Header { get; set; }
        public string MessageText { get; set; }

        public string SelectedButton { get; set; }
        public string SelectedImage { get; set; }

        public Other.SimpleCommand ShowCommand { get; set; }
        public Other.SimpleCommand SendMessageBoxCommand { get; set; }

        public void Show()
        {
            MessageBox.Show(MessageText, Header,buttons.First(x=> x.Key == SelectedButton).Value, images.First(x=> x.Key ==SelectedImage).Value);
        }

        public void SendMessage()
        {
            ShowMessageBox message = new ShowMessageBox()
            {
                Buttons = buttons.First(x => x.Key == SelectedButton).Value,
                Image = images.First(x => x.Key == SelectedImage).Value,
                Text = MessageText,
                Header = Header
            };
            client.SendMessage(message.Serialize());
        }
    }
}
