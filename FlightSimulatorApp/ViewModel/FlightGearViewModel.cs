using FlightSimulatorApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        private string cacheIp;
        private int cachePort;

        public void Start(string ip, int port)
        {
            cacheIp = ip;
            cachePort = port;
            model.start(ip, port);
        }
        public void Stop()
        {
            model.disconnect();
            VM_Status = "Disconnected";
        }
        public void reconnect()
        {
            
            new Thread(delegate ()
            {
                Thread.Sleep(8000);
                if (!model.Connected)
                {
                    Start(cacheIp, cachePort);
                }
            }).Start();
        }
        private int statusCounter=0;
        private String status = "";
        public String VM_Status
        {
            get { return status; }
            set
            {
                String val = value;
                Console.WriteLine(status.Contains(value)+value);
                if (!status.Contains(val) && statusCounter < 6 && statusCounter != 0)
                {
                    statusCounter += 1;
                    status += "\n" + val;
                }
                else
                {
                    if (!value.Contains("Plain"))
                    {
                        status = val;
                        statusCounter = 1;
                    } else if(!status.Contains(val))
                    {
                        status = val;
                        statusCounter = 1;
                    }
                }
                NotifyPropertyChanged("VM_Status"); 
            }
        }
        public String VM_Port
        {
            get { return model.Port; }
            set
            {
                model.Port = value;
            }
        }

        public String VM_Ip
        {
            get { return model.Ip; }
            set
            {
                model.Ip = value;
            }
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
                    VM_Status = "Plain is out of the map!";
                    return 180;
                    
                }
                else if (model.Longitude < -180)
                {
                    VM_Status = "Plain is out of the map!";
                    return -180;
                }
                return Convert.ToDouble(Convert.ToInt32(model.Longitude * 100)) / 100; }
       }
        public double VM_Latitude
        {
            get {
                if (model.Longitude > 90)
                {
                    VM_Status = "Plain is out of the map!";
                    return 90;
                }
                else if (model.Longitude < -90)
                {
                    VM_Status = "Plain is out of the map!";
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
        public Boolean VM_Connected
        {
            get {
                if (model.Connected)
                {
                    VM_Status = "Connected To FlightGear!";
                }
                else
                {
                    //VM_Status = "Disonnected";
                }
                return model.Connected; 
            }
        }

        public Boolean VM_DisconnectedDueTOError
        {
            get 
            {
                if (model.DisconnectedDueTOError)
                {
                    VM_Status = "Error from server, try to Reconnect..";
                }
                return model.DisconnectedDueTOError;
            }
        }
    }
}
