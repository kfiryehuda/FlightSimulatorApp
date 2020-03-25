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

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IFlightGearViewModel vm;
        private Client client;
        public MainWindow()
        {
            InitializeComponent();
            client = new Client();
            //client.connect(ip, port);
            vm = new FlightGearViewModel(new FlightGearModel(client));
            DataContext = vm;
            controller.DataContext = vm;
            controller.joy.DataContext = vm;
            map.DataContext = vm;
            disconnectButton.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connectButton.IsEnabled = false;
            Connect connect = new Connect();
            connect.client = client;
            connect.vm = vm;
            connect.Show();
            disconnectButton.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            disconnectButton.IsEnabled = false;
            client.disconnect();
            connectButton.IsEnabled = true;
        }
    }
}
