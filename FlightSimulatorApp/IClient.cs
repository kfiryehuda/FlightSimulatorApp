using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    public interface IClient : INotifyPropertyChanged
    {
        Boolean connect(string ip, int port);
        string  writeAndRead(string command);
        Boolean Connected { set; get; }
        void disconnect();
    }
}
