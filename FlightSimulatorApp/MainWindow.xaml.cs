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

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //private Point firstPoint = new Point();
        //private void joy_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if(e.ChangedButton == MouseButton.Left) { firstPoint = e.GetPosition(this); }
        //}
        
        //private void joy_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    if (e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        //joy.knobPosition.X = e.GetPosition(this).X + joy.knobPosition.X - firstPoint.X;
        //        //joy.knobPosition.Y = e.GetPosition(this).Y + joy.knobPosition.Y - firstPoint.Y;
        //        joy.knobPosition.X = e.GetPosition(this).X - firstPoint.X;
        //        joy.knobPosition.Y = e.GetPosition(this).Y - firstPoint.Y;
                
        //    }
        //}
    }
}
