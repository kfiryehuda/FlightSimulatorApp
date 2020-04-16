using System.ComponentModel;

namespace FlightSimulatorApp.ViewModel
{
    /// <summary>
    /// The view model interface.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IFlightGearViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Starts the specified ip.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        void Start(string ip, int port);
        /// <summary>
        /// Stops this instance.
        /// </summary>
        void Stop();
        /// <summary>
        /// Reconnects this instance.
        /// </summary>
        void Reconnect();
    }

}
