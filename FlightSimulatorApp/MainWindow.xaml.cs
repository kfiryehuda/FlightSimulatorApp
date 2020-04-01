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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using FlightSimulatorApp.Models;
using FlightSimulatorApp.ViewModel;
using System.Threading;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IFlightGearViewModel vm;
        private Client client;
        private Connect connectWindow;
        public MainWindow()
        {
           
            InitializeComponent();
            client = new Client();
            vm = new FlightGearViewModel(new FlightGearModel(client));
            DataContext = vm;
            map.DataContext = vm;
            disconnectButton.IsEnabled = false;
            connectWindow = new Connect();
            string s = "kfir";

            Console.WriteLine(s.Contains("k"));
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
            if(serverStatus.Text == "True")
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
