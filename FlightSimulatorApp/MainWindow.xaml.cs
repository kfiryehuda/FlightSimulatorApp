using FlightSimulatorApp.Models;
using FlightSimulatorApp.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FlightGearViewModel vm;
        private Client client;
        private Connect connectWindow;
        public MainWindow()
        {

            InitializeComponent();
            client = new Client();
            vm = new FlightGearViewModel(new FlightGearModel(client));
            DataContext = vm;
            map.DataContext = vm;
            controller.SetViewModel(vm);

            disconnectButton.IsEnabled = false;
            connectWindow = new Connect();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connectWindow.vm = vm;
            connectWindow.showW();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            vm.Stop();
        }
        private void serverStatus_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (serverStatus.Text == "True")
            {
                connectButton.IsEnabled = false;
                disconnectButton.IsEnabled = true;
            }
            else
            {
                connectButton.IsEnabled = true;
                disconnectButton.IsEnabled = false;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (disconnectServerErrLbl.Text == "True")
            {

                //disconnectServerErr.Content = "Error from server disconnecting... Try Reconnecting";
                //disconnectServerErr.Visibility = Visibility.Visible;
                //vm.reconnect();
            }
            else
            {
                //disconnectServerErr.Visibility = Visibility.Hidden;
            }

        }
        //Method to implement syncronization using Mutex  


    }
}
