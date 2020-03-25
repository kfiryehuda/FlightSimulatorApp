using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.ViewModel
{
    public interface IFlightGearViewModel : INotifyPropertyChanged
    {
        void Start();

    }

}
