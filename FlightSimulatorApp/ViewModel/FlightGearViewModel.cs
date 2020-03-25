using FlightSimulatorApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.ViewModel
{
    class FlightGearViewModel : IFlightGearViewModel
    {
        private IFlightGearModel model;
        public event PropertyChangedEventHandler PropertyChanged;
        public FlightGearViewModel(IFlightGearModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
             {
                 NotifyPropertyChanged("VM_" + e.PropertyName);
             };
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private double rudder, elevator, aileron, throttle;
        public double VM_Rudder
        {
            get { return rudder; }
            set { rudder = value; model.Rudder = value; }
        }
        public double VM_Elevator
        {
            get { return elevator; }
            set { elevator = value; model.Elevator = value; }
        }
        public double VM_Aileron
        {
            get { return aileron; }
            set { aileron = value; model.Aileron = value; }
        }
        public double VM_Throttle
        {
            get { return throttle; }
            set { throttle = value; model.Throttle = value; }
        }
    }
}
