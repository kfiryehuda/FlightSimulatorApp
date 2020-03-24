using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net;
using System.Net.Sockets;

using System.IO;


namespace FlightSimulatorApp
{

    public class Client : IClient
    {

        TcpClient tcpClient = new TcpClient();
        NetworkStream netStream;
        public void connect(string ip, int port)
        {

            try
            {
                Console.WriteLine("Connecting.....");
                tcpClient.Connect(ip, port);
                // use the ipaddress as in the server program
                Console.WriteLine("Connected");

                String str = Console.ReadLine();
                netStream = tcpClient.GetStream();

            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }

        public void disconnect()
        {
            netStream.Close();
            tcpClient.Close();
        }

        public string read()
        {
           if (netStream.CanRead)
            {
                // Reads NetworkStream into a byte buffer.
                byte[] bytes = new byte[tcpClient.ReceiveBufferSize];

                // Read can return anything from 0 to numBytesToRead. 
                // This method blocks until at least one byte is read.
                netStream.Read(bytes, 0, (int)tcpClient.ReceiveBufferSize);

                // Returns the data received from the host to the console.
                string returndata = Encoding.UTF8.GetString(bytes);

                Console.WriteLine("This is what the host returned to you: " + returndata);
                return returndata;
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

        public void write(string command)
        {
            if (netStream.CanWrite)
            {
                Byte[] sendBytes = Encoding.UTF8.GetBytes(command);
                netStream.Write(sendBytes, 0, sendBytes.Length);

            }
            else
            {
                Console.WriteLine("You cannot write data to this stream.");
                tcpClient.Close();

                // Closing the tcpClient instance does not close the network stream.
                netStream.Close();
                return;
            }


        }
    }
}
