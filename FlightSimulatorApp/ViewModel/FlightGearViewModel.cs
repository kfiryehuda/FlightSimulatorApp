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
        private FlightGearModel model;
        public event PropertyChangedEventHandler PropertyChanged;
        public FlightGearViewModel(FlightGearModel model)
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
            set { rudder = value/170; model.Rudder = value/170; }
            
        }
        public double VM_Elevator
        {
            get { return elevator; }
            set { elevator = value/170; model.Elevator = value/170; }
            
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
            get { 
                return model.Longitude; }
            
        }

        public double VM_Latitude
        {
            get { return model.Latitude; }

        }

        public GeoCoordinate VM_Location
        {
            get { return new GeoCoordinate(VM_Latitude, VM_Longitude); }

        }
        public String VM_Location_str
        {
            get { return model.Location_str;}

        }
        
            

    }
}
