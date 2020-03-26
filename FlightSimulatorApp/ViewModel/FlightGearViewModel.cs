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

        public void Start(string ip, int port)
        {
 
            model.start(ip, port);
        }

        public void Stop()
        {
            model.disconnect();
        }

        private double rudder, elevator, aileron, throttle;
        public double VM_Rudder
        {
            get { return Convert.ToDouble(Convert.ToInt32(rudder * 100))/100; }
            set { rudder = value / 170; model.Rudder = value/170; }
            
        }
        public double VM_Elevator
        {
            get { return Convert.ToDouble(Convert.ToInt32(elevator * 100)) / 100; }
            set { elevator = value / 170; model.Elevator = value / 170; }
            
        }
        public double VM_Aileron
        {
            get { return Convert.ToDouble(Convert.ToInt32(aileron * 100)) / 100; }
            set { aileron = value; model.Aileron = value; }
        }
        public double VM_Throttle
        {
            get { return Convert.ToDouble(Convert.ToInt32(throttle * 100)) / 100; }
            set { throttle = value; model.Throttle = value; }
        }
        public double VM_Longitude
        {
            get {
                if (model.Longitude > 180)
                {
                    return 180;
                    
                }
                else if (model.Longitude < -180)
                {
                    return -180;
                }
                return Convert.ToDouble(Convert.ToInt32(model.Longitude * 100)) / 100; }
       }
        public double VM_Latitude
        {
            get {
                if (model.Longitude > 90)
                {
                    return 90;
                }
                else if (model.Longitude < -90)
                {
                    return -90;
                }
                return Convert.ToDouble(Convert.ToInt32(model.Latitude * 100)) / 100;}
        }
        public GeoCoordinate VM_Location
        {
            get { return new GeoCoordinate(VM_Latitude, VM_Longitude); }
        }


        public String VM_Location_str
        {
            get { return Convert.ToString(VM_Latitude + "," + VM_Longitude); }
        }

        public double VM_Air_speed
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Air_speed *100))/100; }

        }


        public double VM_Altitude
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Altitude * 100)) / 100; }

        }

        public double VM_Roll
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Roll * 100))/ 100; }

        }


        public double VM_Pitch
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Pitch * 100)) / 100; }

        }


        public double VM_Altimeter
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Altimeter * 100)) / 100; }

        }


        public double VM_Heading
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Heading * 100)) / 100 ; }

        }


        public double VM_Ground_speed
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Ground_speed * 100)) / 100 ; }

        }


        public double VM_Vertical_speed
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Vertical_speed * 100)) / 100; }

        }




    }
}
