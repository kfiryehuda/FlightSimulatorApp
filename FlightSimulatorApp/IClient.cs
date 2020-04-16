using System;
using System.ComponentModel;

namespace FlightSimulatorApp
{
    public interface IClient : INotifyPropertyChanged
    {
        Boolean connect(string ip, int port);
        string writeAndRead(string command);
        Boolean Connected { set; get; }
        void disconnect();
    }
}
