using FlightSimulatorApp.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for joistick.xaml
    /// </summary>
    public partial class Joistick : UserControl
    {
        private FlightGearViewModel vm;
        /// <summary>Initializes a new instance of the <see cref="Joistick" /> class.</summary>
        public Joistick()
        {
            InitializeComponent();
        }
        /// <summary>Sets the view model.</summary>
        /// <param name="vm">The veiew model.</param>
        public void SetViewModel(FlightGearViewModel vm)
        {
            this.vm = vm;
        }
        /// <summary>Handles the Completed event of the CenterKnob control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void CenterKnob_Completed(object sender, EventArgs e)
        {
            Storyboard sb = (Storyboard)Knob.FindResource("CenterKnob");
            sb.Stop();
            knobPosition.X = 0;
            knobPosition.Y = 0;
        }
        private Point firstPoint = new Point();
        /// <summary>Handles the MouseDown event of the Knob control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs" /> instance containing the event data.</param>
        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                firstPoint = e.GetPosition(Base);
            }
            Knob.CaptureMouse();
        }
        /// <summary>Handles the MouseMove event of the Knob control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(Base).X - firstPoint.X;
                double y = e.GetPosition(Base).Y - firstPoint.Y;
                if (Math.Sqrt(x * x + y * y) < Base.Width / 2)
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                    vm.VM_Rudder = x;
                    vm.VM_Elevator = y;

                }
            }
        }
        /// <summary>Handles the MouseUp event of the Knob control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs" /> instance containing the event data.</param>
        private void Knob_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Knob.ReleaseMouseCapture();
            Storyboard sb = (Storyboard)Knob.FindResource("CenterKnob");
            sb.Begin();
        }
    }
}
