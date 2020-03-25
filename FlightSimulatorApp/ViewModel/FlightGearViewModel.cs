using FlightSimulatorApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.ViewModel
{
    public class FlightGearViewModel : IFlightGearViewModel
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

        public void Start()
        {
            model.start();
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

        public double VM_Longitude
        {
            get { return model.Longitude; }
            
        }

        public double VM_Latitude
        {
            get { return model.Latitude; }

        }

        public GeoCoordinate VM_Location
        {
            get { return new GeoCoordinate(VM_Latitude, VM_Longitude); }

        }
        String location_str;
        public String Location_str
        {
            get { return Convert.ToString(VM_Latitude) + "," +Convert.ToString(VM_Longitude); }

        }
        
            

    }
}
