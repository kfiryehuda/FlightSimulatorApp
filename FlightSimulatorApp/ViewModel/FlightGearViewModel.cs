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

        public double VM_Rudder
        {
            get { return model.Rudder; }
            
        }
        public double VM_Elevator
        {
            get { return model.Elevator; }
            
        }
        public double VM_Aileron
        {
            get { return model.Aileron; }
            
        }
        public double VM_Throttle
        {
            get { return model.Throttle; }
            
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
