using FlightSimulatorApp.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for controller.xaml
    /// </summary>
    public partial class controller : UserControl
    {
        public void SetViewModel(FlightGearViewModel vm)
        {
            joy.SetViewModel(vm);
        }
        public controller()
        {
            InitializeComponent();
        }

        private void joy_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
