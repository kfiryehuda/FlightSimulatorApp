
using FlightSimulatorApp.ViewModel;
using System;
using System.Configuration;
using System.Windows;

namespace FlightSimulatorApp
{
    /// <summary>
    /// The Connect Window.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class Connect : Window
    {
        public Boolean isFocus;
        /// <summary>
        /// Initializes a new instance of the <see cref="Connect"/> class.
        /// </summary>
        public Connect()
        {
            InitializeComponent();
            port.Text = ConfigurationManager.AppSettings.Get("Port");
            ip.Text = ConfigurationManager.AppSettings.Get("IP");
        }
        public IFlightGearViewModel vm;
        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.Start(ip.Text, Convert.ToInt32(port.Text));
            this.Hide();
        }
        /// <summary>
        /// Shows the window.
        /// </summary>
        public void showW()
        {
            this.Show();
            isFocus = true;
        }
        /// <summary>
        /// Handles the LostFocus event of the ConnectWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ConnectWindow_LostFocus(object sender, RoutedEventArgs e)
        {
            isFocus = false;
        }
    }
}
