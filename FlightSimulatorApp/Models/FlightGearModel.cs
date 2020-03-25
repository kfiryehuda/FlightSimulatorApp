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
            this.stop = false;
        }
        private double rudder=0;
        public double Rudder { 
            get { return rudder; } 
            set {
                rudder = value;
                client.write("set /controls/flight/rudder " + rudder + "\n");
                client.read();
                this.NotifyPropertyChanged("Rudder");

            }
        }
        private double elevator=0;
        public double Elevator
        {
            get { return elevator; }
            set
            {
                elevator = value;
                client.write("set /controls/flight/elevator " + elevator + "\n");
                client.read();
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
                client.write("set /controls/flight/aileron " + aileron + "\n");
                client.read();
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

                client.write("set /controls/engines/current-engine/throttle " + throttle + "\n");
                client.read();
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
        public void connect(string ip, int port)
        {
            client.connect(ip, port);
        }

        public void disconnect()
        {
            client.disconnect();
        }
        
        public void start()
        {
            new Thread(delegate ()
            {
                while (!stop)
                {
                    //write all the rpoperty to the client
                    client.write("get /position/latitude-deg\n");
                    //receve all property neaded from the client
                    //Console.WriteLine(client.read());
                    this.Latitude = Convert.ToDouble(client.read()) ;
                    //write all the rpoperty to the client
                    client.write("get /position/longitude-deg\n");
                    //receve all property neaded from the client
                    //Console.WriteLine(client.read());
                    this.Longitude = Convert.ToDouble(client.read());
                    Thread.Sleep(250);
                }
            }).Start();
        }
    }
}
