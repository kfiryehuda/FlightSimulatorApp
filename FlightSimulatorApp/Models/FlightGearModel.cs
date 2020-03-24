using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Models
{
    class FlightGearModel : IFlightGearModel
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
                Console.WriteLine("throttle" + value);
                //Console.WriteLine("read" + client.read()) ;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
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
                    client.write("");
                    //receve all property neaded from the client
                    string  r = client.read();

                    Thread.Sleep(250);
                }
            }).Start();
        }
    }
}
