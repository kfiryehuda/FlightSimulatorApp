using System;
using System.ComponentModel;
using System.Device.Location;

namespace FlightSimulatorApp.Models
{
    /// <summary>
    /// The model interface.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IFlightGearModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        void Disconnect();
        /// <summary>
        /// Starts the specified ip.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        void Start(string ip, int port);
        /// <summary>
        /// Gets or sets the ip.
        /// </summary>
        /// <value>
        /// The ip.
        /// </value>
        string Ip { set; get; }
        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        string Port { set; get; }
        /// <summary>
        /// Gets or sets the rudder.
        /// </summary>
        /// <value>
        /// The rudder.
        /// </value>
        double Rudder { set; get; }
        /// <summary>
        /// Gets or sets the elevator.
        /// </summary>
        /// <value>
        /// The elevator.
        /// </value>
        double Elevator { set; get; }
        /// <summary>
        /// Gets or sets the aileron.
        /// </summary>
        /// <value>
        /// The aileron.
        /// </value>
        double Aileron { set; get; }
        /// <summary>
        /// Gets or sets the throttle.
        /// </summary>
        /// <value>
        /// The throttle.
        /// </value>
        double Throttle { set; get; }
        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        double Latitude { set; get; }
        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        double Longitude { set; get; }
        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        GeoCoordinate Location { get; set; }
        /// <summary>
        /// Gets or sets the air speed.
        /// </summary>
        /// <value>
        /// The air speed.
        /// </value>
        double Air_speed { get; set; }
        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        /// <value>
        /// The altitude.
        /// </value>
        double Altitude { get; set; }
        /// <summary>
        /// Gets or sets the roll.
        /// </summary>
        /// <value>
        /// The roll.
        /// </value>
        double Roll { get; set; }
        /// <summary>
        /// Gets or sets the pitch.
        /// </summary>
        /// <value>
        /// The pitch.
        /// </value>
        double Pitch { get; set; }
        /// <summary>
        /// Gets or sets the altimeter.
        /// </summary>
        /// <value>
        /// The altimeter.
        /// </value>
        double Altimeter { get; set; }
        /// <summary>
        /// Gets or sets the heading.
        /// </summary>
        /// <value>
        /// The heading.
        /// </value>
        double Heading { get; set; }
        /// <summary>
        /// Gets or sets the ground speed.
        /// </summary>
        /// <value>
        /// The ground speed.
        /// </value>
        double Ground_speed { get; set; }
        /// <summary>
        /// Gets or sets the vertical speed.
        /// </summary>
        /// <value>
        /// The vertical speed.
        /// </value>
        double Vertical_speed { get; set; }
        /// <summary>
        /// Gets or sets the location string.
        /// </summary>
        /// <value>
        /// The location string.
        /// </value>
        String Location_str { set; get; }
        /// <summary>
        /// Gets a value indicating whether this <see cref="IFlightGearModel"/> is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if connected; otherwise, <c>false</c>.
        /// </value>
        Boolean Connected { get; }
        /// <summary>
        /// Gets a value indicating whether [disconnected due to error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [disconnected due to error]; otherwise, <c>false</c>.
        /// </value>
        Boolean DisconnectedDueTOError { get; }


    }
}



