﻿
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
