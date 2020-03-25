using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    public interface IClient
    {
        Boolean connect(string ip, int port);
        string  writeAndRead(string command);

        void disconnect();
    }
}
