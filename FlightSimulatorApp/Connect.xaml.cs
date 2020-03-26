
using FlightSimulatorApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for Connect.xaml
    /// </summary>
    public partial class Connect : Window
    {
        
        public Connect()
        {
            InitializeComponent();
            port.Text = ConfigurationManager.AppSettings.Get("Port");
            ip.Text = ConfigurationManager.AppSettings.Get("IP");
        }
        public Client client { get; set; }
        public IFlightGearViewModel vm;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(port.Text);

            vm.Start(ip.Text, Convert.ToInt32(port.Text));
            this.Hide();


        }
    }
}
