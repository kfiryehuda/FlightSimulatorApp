using FlightSimulatorApp.Models;
using System;
using System.ComponentModel;
using System.Device.Location;
using System.Threading;

namespace FlightSimulatorApp.ViewModel
{
    /// <summary>
    /// The main veiw model.
    /// </summary>
    /// <seealso cref="FlightSimulatorApp.ViewModel.IFlightGearViewModel" />
    public class FlightGearViewModel : IFlightGearViewModel
    {
        private readonly IFlightGearModel model;
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightGearViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public FlightGearViewModel(IFlightGearModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
             {
                 NotifyPropertyChanged("VM_" + e.PropertyName);
             };
        }

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="propName">Name of the property.</param>
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        private string cacheIp;
        private int cachePort;

        /// <summary>
        /// Starts the specified ip.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        public void Start(string ip, int port)
        {
            VM_Status = "Connecting...";
            cacheIp = ip;
            cachePort = port;
            model.Start(ip, port);
        }
        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            model.Disconnect();
            VM_Status = "Disconnected";
        }
        /// <summary>
        /// Reconnects this instance.
        /// </summary>
        public void Reconnect()
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
        private int statusCounter = 0;
        private String status = "";
        /// <summary>
        /// Gets or sets the vm status.
        /// </summary>
        /// <value>
        /// The vm status.
        /// </value>
        public String VM_Status
        {
            get { return status; }
            set
            {
                String val = value;
                Console.WriteLine(status.Contains(value) + value);
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
                    }
                    else if (!status.Contains(val))
                    {
                        status = val;
                        statusCounter = 1;
                    }
                }
                NotifyPropertyChanged("VM_Status");
            }
        }
        /// <summary>
        /// Gets or sets the vm port.
        /// </summary>
        /// <value>
        /// The vm port.
        /// </value>
        public String VM_Port
        {
            get { return model.Port; }
            set
            {
                model.Port = value;
            }
        }

        /// <summary>
        /// Gets or sets the vm ip.
        /// </summary>
        /// <value>
        /// The vm ip.
        /// </value>
        public String VM_Ip
        {
            get { return model.Ip; }
            set
            {
                model.Ip = value;
            }
        }
        private double rudder, elevator, aileron, throttle;
        /// <summary>
        /// Gets or sets the vm rudder.
        /// </summary>
        /// <value>
        /// The vm rudder.
        /// </value>
        public double VM_Rudder
        {
            get { return Convert.ToDouble(Convert.ToInt32(rudder * 100)) / 100; }
            set { rudder = value / 170; model.Rudder = value / 170; }
        }
        /// <summary>
        /// Gets or sets the vm elevator.
        /// </summary>
        /// <value>
        /// The vm elevator.
        /// </value>
        public double VM_Elevator
        {
            get { return Convert.ToDouble(Convert.ToInt32(elevator * 100)) / 100; }
            set { elevator = value / 170; model.Elevator = value / 170; }
        }
        /// <summary>
        /// Gets or sets the vm aileron.
        /// </summary>
        /// <value>
        /// The vm aileron.
        /// </value>
        public double VM_Aileron
        {
            get { return Convert.ToDouble(Convert.ToInt32(aileron * 100)) / 100; }
            set { aileron = value; model.Aileron = value; }
        }
        /// <summary>
        /// Gets or sets the vm throttle.
        /// </summary>
        /// <value>
        /// The vm throttle.
        /// </value>
        public double VM_Throttle
        {
            get { return Convert.ToDouble(Convert.ToInt32(throttle * 100)) / 100; }
            set { throttle = value; model.Throttle = value; }
        }
        /// <summary>
        /// Gets the vm longitude.
        /// </summary>
        /// <value>
        /// The vm longitude.
        /// </value>
        public double VM_Longitude
        {
            get
            {
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
                return Convert.ToDouble(Convert.ToInt32(model.Longitude * 100)) / 100;
            }
        }
        /// <summary>
        /// Gets the vm latitude.
        /// </summary>
        /// <value>
        /// The vm latitude.
        /// </value>
        public double VM_Latitude
        {
            get
            {
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
                return Convert.ToDouble(Convert.ToInt32(model.Latitude * 100)) / 100;
            }
        }
        /// <summary>
        /// Gets the vm location.
        /// </summary>
        /// <value>
        /// The vm location.
        /// </value>
        public GeoCoordinate VM_Location
        {
            get { return new GeoCoordinate(VM_Latitude, VM_Longitude); }
        }


        /// <summary>
        /// Gets the vm location string.
        /// </summary>
        /// <value>
        /// The vm location string.
        /// </value>
        public String VM_Location_str
        {
            get { return Convert.ToString(VM_Latitude + "," + VM_Longitude); }
        }

        /// <summary>
        /// Gets the vm air speed.
        /// </summary>
        /// <value>
        /// The vm air speed.
        /// </value>
        public double VM_Air_speed
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Air_speed * 100)) / 100; }

        }


        /// <summary>
        /// Gets the vm altitude.
        /// </summary>
        /// <value>
        /// The vm altitude.
        /// </value>
        public double VM_Altitude
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Altitude * 100)) / 100; }

        }

        /// <summary>
        /// Gets the vm roll.
        /// </summary>
        /// <value>
        /// The vm roll.
        /// </value>
        public double VM_Roll
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Roll * 100)) / 100; }

        }

        /// <summary>
        /// Gets the vm pitch.
        /// </summary>
        /// <value>
        /// The vm pitch.
        /// </value>
        public double VM_Pitch
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Pitch * 100)) / 100; }

        }

        /// <summary>
        /// Gets the vm altimeter.
        /// </summary>
        /// <value>
        /// The vm altimeter.
        /// </value>
        public double VM_Altimeter
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Altimeter * 100)) / 100; }

        }

        /// <summary>
        /// Gets the vm heading.
        /// </summary>
        /// <value>
        /// The vm heading.
        /// </value>
        public double VM_Heading
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Heading * 100)) / 100; }

        }

        /// <summary>
        /// Gets the vm ground speed.
        /// </summary>
        /// <value>
        /// The vm ground speed.
        /// </value>
        public double VM_Ground_speed
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Ground_speed * 100)) / 100; }

        }

        /// <summary>
        /// Gets the vm vertical speed.
        /// </summary>
        /// <value>
        /// The vm vertical speed.
        /// </value>
        public double VM_Vertical_speed
        {
            get { return Convert.ToDouble(Convert.ToInt32(model.Vertical_speed * 100)) / 100; }

        }
        public Boolean VM_Connected
        {
            get
            {
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

        /// <summary>
        /// Gets a value indicating whether [vm disconnected due to error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [vm disconnected due to error]; otherwise, <c>false</c>.
        /// </value>
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
