using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Models
{
    public interface IFlightGearModel : INotifyPropertyChanged
    {

        void disconnect();
        void start(string ip, int port);

        // TODO add map property

        // joystick property
        double Rudder { set; get; }
        double Elevator { set; get; }
        double Aileron { set; get; }
        double Throttle { set; get; }
        double Latitude { set; get; }
        double Longitude { set; get; }
        GeoCoordinate Location { get; set; }
        double Air_speed { get; set; }
        double Altitude { get; set; }
        double Roll { get; set; }
        double Pitch { get; set; }
        double Altimeter { get; set; }
        double Heading { get; set; }
        double Ground_speed { get; set; }
        double Vertical_speed { get; set; }
        String Location_str { set; get; }

    }
}



