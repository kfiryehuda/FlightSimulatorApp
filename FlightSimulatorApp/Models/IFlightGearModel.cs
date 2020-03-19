using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Models
{
    interface IFlightGearModel : INotifyPropertyChanged
    {
        void connect(string ip, int port);
        void disconnect();
        void start();

        // TODO add map property

        // joystick property
        double Rudder { set; get; }
        double Elevator { set; get; }
        double Aileron { set; get; }
        double Throttle { set; get; }

    }
}
