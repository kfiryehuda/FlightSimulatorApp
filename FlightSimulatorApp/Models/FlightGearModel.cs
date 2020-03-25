using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Models
{
    public class FlightGearModel : IFlightGearModel
    {


        private IClient client;
        volatile Boolean stop;
        public FlightGearModel(IClient client)
        {
            this.client = client;

        }
        private double rudder;
        public double Rudder { 
            get { return rudder; } 
            set {
               
                rudder = value;

                client.writeAndRead("set /controls/flight/rudder " + rudder + "\n");
                this.NotifyPropertyChanged("Rudder");
                
            }
        }
        private double elevator;
        public double Elevator
        {
            get { return elevator; }
            set
            {
                
                elevator = value;

                client.writeAndRead("set /controls/flight/elevator " + elevator + "\n");
                this.NotifyPropertyChanged("Elevator");
                
            }
        }
        private double aileron;
        public double Aileron
        {
            get { return aileron; }
            set
            {
                
                aileron = value;
                // TODO nead to change!

                client.writeAndRead("set /controls/flight/aileron " + aileron + "\n");
                this.NotifyPropertyChanged("Aileron");
                
            }
        }
        private double throttle;
        public double Throttle
        {
            get { return throttle; }
            set
            {
                
                throttle = value;

                client.writeAndRead("set /controls/engines/current-engine/throttle " + throttle + "\n");
                this.NotifyPropertyChanged("Throttle");
                
                //Console.WriteLine("read" + client.read()) ;
            }
        }
        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                this.NotifyPropertyChanged("Longitude");
                //client.write("get /position/longitude-deg " + longitude + "\n");

                //Console.WriteLine("read" + client.read()) ;
            }
        }

        private double latitude;
        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                this.NotifyPropertyChanged("Latitude");
                //client.write("get /position/latitude-deg " + latitude + "\n");

                //Console.WriteLine("read" + client.read()) ;
            }
        }
        private GeoCoordinate location;
        public GeoCoordinate Location { 
            get { return location; }

            set { location = value;
                this.NotifyPropertyChanged("Location");}
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }


        }

        private double air_speed;
        public double Air_speed
        {
            get { return air_speed; }
            set
            {
                air_speed = value;
                this.NotifyPropertyChanged("Air_speed");
            }
        }

        private double altitude;
        public double Altitude
        {
            get { return altitude; }
            set
            {
                altitude = value;
                this.NotifyPropertyChanged("Altitude");
            }
        }
        private double roll;
        public double Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                this.NotifyPropertyChanged("Roll");
            }
        }

        private double pitch;
        public double Pitch
        {
            get { return pitch; }
            set
            {
                pitch = value;
                this.NotifyPropertyChanged("Pitch");
            }
        }
        private double altimeter;
        public double Altimeter
        {
            get { return altimeter; }
            set
            {
                altimeter = value;
                this.NotifyPropertyChanged("Altimeter");
            }
        }

        private double heading;
        public double Heading
        {
            get { return heading; }
            set
            {
                heading = value;
                this.NotifyPropertyChanged("Heading");
            }
        }
        private double ground_speed;
        public double Ground_speed
        {
            get { return ground_speed; }
            set
            {
                ground_speed = value;
                this.NotifyPropertyChanged("Ground_speed");
            }
        }

        private double vertical_speed;
        public double Vertical_speed
        {
            get { return vertical_speed; }
            set
            {
                vertical_speed = value;
                this.NotifyPropertyChanged("Vertical_speed");
            }
        }
        
        private String location_str;
        public String Location_str
        {
            get { return location_str; }
            set
            {
                location_str = value;
                this.NotifyPropertyChanged("Location_str");
                //client.write("get /position/latitude-deg " + latitude + "\n");

                //Console.WriteLine("read" + client.read()) ;
            }
        }


        public void disconnect()
        {
            stop = true;
            client.disconnect();
        }



        public void start(string ip, int port)
        {
           
            if(!client.connect(ip, port)){
                return;
            }
           
            stop = false;
            new Thread(delegate ()
            {

                while (!stop)
                {
                    
                        this.Latitude = Convert.ToDouble(client.writeAndRead("get /position/latitude-deg\n"));

                        this.Longitude = Convert.ToDouble(client.writeAndRead("get /position/longitude-deg\n"));

                        this.Air_speed = Convert.ToDouble(client.writeAndRead("get /instrumentation/airspeed-indicator/indicated-speed-kt\n"));

                        this.Altitude = Convert.ToDouble(client.writeAndRead("get /instrumentation/gps/indicated-altitude-ft\n"));

                        this.Roll = Convert.ToDouble(client.writeAndRead("get /instrumentation/attitude-indicator/internal-roll-deg\n"));

                        this.Pitch = Convert.ToDouble(client.writeAndRead("get /instrumentation/attitude-indicator/internal-pitch-deg\n"));

                        this.Altimeter = Convert.ToDouble(client.writeAndRead("get /instrumentation/altimeter/indicated-altitude-ft\n"));

                        this.Heading = Convert.ToDouble(client.writeAndRead("get /instrumentation/heading-indicator/indicated-heading-deg\n"));

                        this.Ground_speed = Convert.ToDouble(client.writeAndRead("get /instrumentation/gps/indicated-ground-speed-kt\n"));

                        this.Vertical_speed = Convert.ToDouble(client.writeAndRead("get /instrumentation/gps/indicated-vertical-speed\n"));

                        this.Location_str = Convert.ToString(latitude + "," + longitude);
                        Thread.Sleep(250);
                  

                }
            }).Start();
        }
    }
}
