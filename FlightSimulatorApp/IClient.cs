using System;
using System.ComponentModel;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Handle the connection to the server.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IClient : INotifyPropertyChanged
    {
        /// <summary>
        /// Connects the specified ip.
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <returns></returns>
        bool Connect(string ip, int port);
        /// <summary>
        /// Writes the and read.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns></returns>
        string WriteAndRead(string command);
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IClient"/> is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if connected; otherwise, <c>false</c>.
        /// </value>
        Boolean Connected { set; get; }
        /// <summary>
        /// Disconnects this instance.
        /// </summary>
        void Disconnect();
    }
}
