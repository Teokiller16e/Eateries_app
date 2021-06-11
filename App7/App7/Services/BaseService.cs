using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App7.Services
{
    public abstract class BaseService : INotifyPropertyChanged
    {

        public static int Hide_Delayed { get; set; }
        public static string BaseIp { get; set; }
        public static string BaseStatus { get; set; }
        public static string BasePort { get; set; }
        public static int Kds_Code { get; set; }

        static string _BaseURL;

        public static string BaseURL
        {
            get
            {

                _BaseURL = "http://" + BaseIp + ":" + BasePort;
                return _BaseURL;

            }

        }

      //Constructor
        public BaseService()
        {
         

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
