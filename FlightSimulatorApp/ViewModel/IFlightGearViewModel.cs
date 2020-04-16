using System.ComponentModel;

namespace FlightSimulatorApp.ViewModel
{
    public interface IFlightGearViewModel : INotifyPropertyChanged
    {
        void Start(string ip, int port);
        void Stop();
        void reconnect();
    }

}
