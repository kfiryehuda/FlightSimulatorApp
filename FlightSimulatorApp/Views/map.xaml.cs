using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for map.xaml
    /// </summary>
    public partial class map : UserControl
    {

        public map()
        {
            InitializeComponent();
        }

        private void t_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(t.Text == "180" || t.Text == "-180" || t2.Text == "90" || t2.Text == "-90")
            {
                out1.Visibility = Visibility.Visible;
                imageCanvas.Visibility = Visibility.Hidden;
            }
            else
            {
                imageCanvas.Visibility = Visibility.Visible;
                out1.Visibility = Visibility.Hidden;
            }
            
        }

        private void out1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
