using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text;

namespace FlightSimulatorApp
{

    public class Client : IClient
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }


        Object obj = new object();
        TcpClient tcpClient;
        NetworkStream netStream;
        private Boolean connected = false;
        public Boolean Connected
        {
            get { return connected; }
            set
            {
                connected = value;
                this.NotifyPropertyChanged("Connected");
            }
        }
        public Boolean connect(string ip, int port)
        {


            try
            {
                tcpClient = new TcpClient();
                Console.WriteLine("Connecting.....");

                tcpClient.Connect(ip, port);
                // use the ipaddress as in the server program
                Console.WriteLine("Connected");

                //String str = Console.ReadLine();
                netStream = tcpClient.GetStream();
                Connected = true;
                return true;
            }

            catch (Exception e)
            {

                Console.WriteLine("Error..... " + e.StackTrace);
                return false;
            }
        }

        public void disconnect()
        {
            if (Connected)
            {
                netStream.Close();
                tcpClient.Close();
                Connected = false;
            }
            else
            {
                Console.WriteLine("Not connected ");
                return;
            }
        }

        public string writeAndRead(string command)
        {
            if (!Connected)
            {
                return "";
            }
            if (netStream.CanRead && netStream.CanWrite)
            {
                try
                {
                    lock (obj)
                    {

                        Byte[] sendBytes = Encoding.ASCII.GetBytes(command);
                        netStream.Write(sendBytes, 0, sendBytes.Length);
                        // Reads NetworkStream into a byte buffer.
                        byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
                        // Set a 10000 millisecond = 10 sec timeout for reading.
                        netStream.ReadTimeout = 10000;
                        // Read can return anything from 0 to numBytesToRead. 
                        // This method blocks until at least one byte is read.
                        netStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);

                        // Returns the data received from the host to the console.
                        string returndata = Encoding.ASCII.GetString(bytes);

                        return returndata;
                    }
                }

                catch (Exception e)
                {
                    return "";
                }
            }
            else
            {
                Console.WriteLine("You cannot read data from this stream.");
                tcpClient.Close();

                // Closing the tcpClient instance does not close the network stream.
                netStream.Close();
                return "";
            }
        }

    }
}
