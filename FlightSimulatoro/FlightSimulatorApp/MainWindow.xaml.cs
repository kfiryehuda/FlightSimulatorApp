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
        private readonly FlightGearViewModel vm;
        private readonly Client client;
        private readonly Connect connectWindow;
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
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

        /// <summary>
        /// Handles the Click event of the Connect Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connectWindow.vm = vm;
            connectWindow.ShowW();
        }

        /// <summary>
        /// Handles the 1 event of the Disconnect Button_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            vm.Stop();
        }
        /// <summary>
        /// Handles the TextChanged event of the serverStatus control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void ServerStatus_TextChanged(object sender, TextChangedEventArgs e)
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
    }
}
