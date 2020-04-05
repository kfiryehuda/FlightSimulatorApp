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
        volatile Boolean disconnectedDueTOError;

        public FlightGearModel(IClient client)
        {
            this.client = client;
            client.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);
            };
        }
        public Boolean Connected
        {
            get { return client.Connected; }
            set { this.NotifyPropertyChanged("Connected"); }
        }

        public Boolean DisconnectedDueTOError
        {
            get { return disconnectedDueTOError; }
            set {
                disconnectedDueTOError = value;
                this.NotifyPropertyChanged("DisconnectedDueTOError"); }
        }
        private String ip;
        public String Ip
        {
            get { return ip; }
            set
            {

                ip = value;
                this.NotifyPropertyChanged("Ip");

            }
        }
        private String port;
        public String Port
        {
            get { return port; }
            set
            {

                port = value;
                this.NotifyPropertyChanged("Port");
                
            }
        }

        private double rudder;
        public double Rudder { 
            get { return rudder; } 
            set {
                if (value != Double.MaxValue)
                {

                    rudder = value;
                    client.writeAndRead("set /controls/flight/rudder " + rudder + "\n");
                    this.NotifyPropertyChanged("Rudder");
                }
            }
        }


        private double elevator;
        public double Elevator
        {
            get { return elevator; }
            set
            {
                if (value != Double.MaxValue)
                {

                    elevator = value;

                    client.writeAndRead("set /controls/flight/elevator " + elevator + "\n");
                    this.NotifyPropertyChanged("Elevator");
                }
            }
        }
        private double aileron;
        public double Aileron
        {
            get { return aileron; }
            set
            {
                if (value != Double.MaxValue)
                {

                    aileron = value;
                    // TODO nead to change!

                    client.writeAndRead("set /controls/flight/aileron " + aileron + "\n");
                    this.NotifyPropertyChanged("Aileron");
                }
            }
        }
        private double throttle;
        public double Throttle
        {
            get { return throttle; }
            set
            {
                if (value != Double.MaxValue)
                {
                    throttle = value;

                    client.writeAndRead("set /controls/engines/current-engine/throttle " + throttle + "\n");
                    this.NotifyPropertyChanged("Throttle");
                }
                
                //Console.WriteLine("read" + client.read()) ;
            }
        }
        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            set
            {
                if (value != Double.MaxValue)
                {
                    longitude = value;
                    this.NotifyPropertyChanged("Longitude");
                }
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
                if (value != Double.MaxValue)
                {
                    latitude = value;
                    this.NotifyPropertyChanged("Latitude");
                }
                
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
                if (value != Double.MaxValue)
                {

                    air_speed = value;
                    this.NotifyPropertyChanged("Air_speed");
                }
            }
        }

        private double altitude;
        public double Altitude
        {
            get { return altitude; }
            set
            {
                if (value != Double.MaxValue)
                {

                    altitude = value;
                    this.NotifyPropertyChanged("Altitude");
                }
            }
        }
        private double roll;
        public double Roll
        {
            get { return roll; }
            set
            {
                if (value != Double.MaxValue)
                {

                    roll = value;
                    this.NotifyPropertyChanged("Roll");
                }
            }
        }

        private double pitch;
        public double Pitch
        {
            get { return pitch; }
            set
            {
                if (value != Double.MaxValue)
                {

                    pitch = value;
                    this.NotifyPropertyChanged("Pitch");
                }
            }
        }
        private double altimeter;
        public double Altimeter
        {
            get { return altimeter; }
            set
            {
                if (value != Double.MaxValue)
                {

                    altimeter = value;
                    this.NotifyPropertyChanged("Altimeter");
                }
            }
        }

        private double heading;
        public double Heading
        {
            get { return heading; }
            set
            {
                if (value != Double.MaxValue)
                {

                    heading = value;
                    this.NotifyPropertyChanged("Heading");
                }
            }
        }
        private double ground_speed;
        public double Ground_speed
        {
            get { return ground_speed; }
            set
            {
                if (value != Double.MaxValue)
                {

                    ground_speed = value;
                    this.NotifyPropertyChanged("Ground_speed");
                }
            }
        }

        private double vertical_speed;
        public double Vertical_speed
        {
            get { return vertical_speed; }
            set
            {
                if (value != Double.MaxValue)
                {

                    vertical_speed = value;
                    this.NotifyPropertyChanged("Vertical_speed");
                }
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

        

        private Double switchReadWrite(int caseSwitch)
        {
            String strToRet = "";
            Double valToRet;
            switch (caseSwitch)
            {
                case 1:
                    strToRet = client.writeAndRead("get /position/latitude-deg\n");
                    break;
                case 2:
                    strToRet = client.writeAndRead("get /position/longitude-deg\n");
                    break;
                case 3:
                    strToRet = client.writeAndRead("get /instrumentation/airspeed-indicator/indicated-speed-kt\n");
                    break;
                case 4:
                    strToRet = client.writeAndRead("get /instrumentation/gps/indicated-altitude-ft\n");
                    break;
                case 5:
                    strToRet = client.writeAndRead("get /instrumentation/attitude-indicator/internal-roll-deg\n");
                    break;
                case 6:
                    strToRet = client.writeAndRead("get /instrumentation/attitude-indicator/internal-pitch-deg\n");
                    break;
                case 7:
                    strToRet = client.writeAndRead("get /instrumentation/altimeter/indicated-altitude-ft\n");
                    break;
                case 8:
                    strToRet = client.writeAndRead("get /instrumentation/heading-indicator/indicated-heading-deg\n");
                    break;
                case 9:
                    strToRet = client.writeAndRead("get /instrumentation/gps/indicated-ground-speed-kt\n");
                    break;
                case 10:
                    strToRet = client.writeAndRead("get /instrumentation/gps/indicated-vertical-speed\n");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            // Check for empty string.
            if (string.IsNullOrEmpty(strToRet))
            {
                Console.WriteLine("Server not responding more than 10 second, Disconnecting... ");
                throw new Exception();
                
            }
            else if (strToRet.Contains("ERR"))
            {
                Console.WriteLine("Error send from server");
                // max value tells the value is problematic so dont use it
                valToRet = Double.MaxValue;
            }
            else if (IsDouble(strToRet))
            {
                valToRet = Convert.ToDouble(strToRet);
            }
            else
            {
                //if not a number return the max double value
                Console.WriteLine("Disconected to Error message from server");
                throw new Exception();
            }
               
            return valToRet;

        }

        public bool IsDouble(string text)
        {
            Double num = 0;
            bool isDouble = false;

            
            isDouble = Double.TryParse(text, out num);

            return isDouble;
        }
        public void start(string ip, int port)
        {
            new Thread(delegate ()
            {
                if (!client.connect(ip, port))
                {
                    DisconnectedDueTOError = true;
                    return;
                }
                DisconnectedDueTOError = false;
                stop = false;
                Port = Convert.ToString(port);
                Ip = ip;
                while (!stop)
                {
                    try
                    {
                        this.Latitude = switchReadWrite(1);
                        this.Longitude = switchReadWrite(2);
                        this.Air_speed = switchReadWrite(3);
                        this.Altitude = switchReadWrite(4);
                        this.Roll = switchReadWrite(5);
                        this.Pitch = switchReadWrite(6);
                        this.Altimeter = switchReadWrite(7);
                        this.Heading = switchReadWrite(8);
                        this.Ground_speed = switchReadWrite(9);
                        this.Vertical_speed = switchReadWrite(10);
                    }

                    catch (Exception e)
                    {
                        disconnect();
                        DisconnectedDueTOError = true;
                    }
                    this.Location_str = Convert.ToString(latitude + "," + longitude);
                    Thread.Sleep(250);
                }
            }).Start();
        }
    }
}
