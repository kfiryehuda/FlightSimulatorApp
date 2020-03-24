﻿using System;
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
        }
        public Client client { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(port.Text);
            client.connect(ip.Text, Convert.ToInt32(port.Text));
            this.Hide();
        }
    }
}