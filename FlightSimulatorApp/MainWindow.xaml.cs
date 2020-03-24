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
        private FlightGearViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            Client kfir = new Client();
            kfir.connect("10.100.102.8", 5402);
            vm = new FlightGearViewModel(new FlightGearModel(kfir));
            DataContext = vm;
            joy.DataContext = vm;
        }
    }
}
