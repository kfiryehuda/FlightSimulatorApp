
using FlightSimulatorApp.ViewModel;
using System;
using System.Configuration;
using System.Windows;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for Connect.xaml
    /// </summary>
    public partial class Connect : Window
    {
        public Boolean isFocus;
        public Connect()
        {
            InitializeComponent();
            port.Text = ConfigurationManager.AppSettings.Get("Port");
            ip.Text = ConfigurationManager.AppSettings.Get("IP");
        }
        public IFlightGearViewModel vm;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.Start(ip.Text, Convert.ToInt32(port.Text));
            this.Hide();
        }
        public void showW()
        {
            this.Show();
            isFocus = true;
        }
        private void ConnectWindow_LostFocus(object sender, RoutedEventArgs e)
        {
            isFocus = false;
        }
    }
}
