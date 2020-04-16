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
        /// <summary>
        /// Sets the view model.
        /// </summary>
        /// <param name="vm">The vm.</param>
        public void SetViewModel(FlightGearViewModel vm)
        {
            joy.SetViewModel(vm);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="controller"/> class.
        /// </summary>
        public controller()
        {
            InitializeComponent();
        }
    }
}
