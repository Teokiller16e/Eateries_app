using App7.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace App7.ViewModel
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        private string _port;
        private string _ipAddress;
        private int _kds_Code;
        private int _hide_Delayed;
        private string _status;
        private bool _visibility;
        private static int _flagVariable;
        public string BackgroundColor1 { get; set; }
        public string BackgroundColor2 { get; set; }
        public string BackgroundColor3 { get; set; }
        public string BackgroundColor4 { get; set; }

        public enum Colorbutton
        {
            Button1 = 1,
            Button2 = 2,
            Button3 = 3,
            Button4 = 4
        };

        public static Colorbutton Xrwma;


        public SettingsViewModel() //int flag)
        {

            Initialize();
        
        }
      

        public void Initialize()
        {

            Visibility = new bool();
            Status = BaseService.BaseStatus;
            Kds_Code = Convert.ToInt32 (Utils.Settings.LastCodeUsedSettings);
            Hide_Delayed = Convert.ToInt32(Utils.Settings.LastHide_DelayedSettings);
            Xrwma = (Colorbutton) Convert.ToInt32 (Utils.Settings.LastChoiceUsedSettings);
            IpAddress = Utils.Settings.LastiPUsedSettings;
            Port =Utils.Settings.LastPortUsedSettings;


            switch(Xrwma)
            {
                case Colorbutton.Button1:
                    BackgroundColor1 = "Green";
                    BackgroundColor2 = "#1f99ce";
                    BackgroundColor3 = "#1f99ce";
                    BackgroundColor4 = "#1f99ce";

                    OnPropertyChanged("BackgroundColor1");
                    OnPropertyChanged("BackgroundColor2");
                    OnPropertyChanged("BackgroundColor3");
                    OnPropertyChanged("BackgroundColor4");
                    break;

                case Colorbutton.Button2:
                    BackgroundColor1 = "#1f99ce";
                    BackgroundColor2 = "Green";
                    BackgroundColor3 = "#1f99ce";
                    BackgroundColor4 = "#1f99ce";
                    OnPropertyChanged("BackgroundColor1");
                    OnPropertyChanged("BackgroundColor2");
                    OnPropertyChanged("BackgroundColor3");
                    OnPropertyChanged("BackgroundColor4");
                    break;

                case Colorbutton.Button3:
                    BackgroundColor1 = "#1f99ce";
                    BackgroundColor2 = "#1f99ce";
                    BackgroundColor3 = " Green";
                    BackgroundColor4 = "#1f99ce";

                    OnPropertyChanged("BackgroundColor1");
                    OnPropertyChanged("BackgroundColor2");
                    OnPropertyChanged("BackgroundColor3");
                    OnPropertyChanged("BackgroundColor4");
                    break;

                case Colorbutton.Button4:
                    BackgroundColor1 = "#1f99ce";
                    BackgroundColor2 = "#1f99ce";
                    BackgroundColor3 = "#1f99ce";
                    BackgroundColor4 = "Green";

                    OnPropertyChanged("BackgroundColor1");
                    OnPropertyChanged("BackgroundColor2");
                    OnPropertyChanged("BackgroundColor3");
                    OnPropertyChanged("BackgroundColor4");
                    break;
              
            }
        }

 //Tα commands για τα buttons :
        public Command Button1
        {

            get
            {

                return new Command(() =>
                {
                    RefreshClass.Choice = 1;
                    BackgroundColor1 = "Green";
                    BackgroundColor2 = "#1f99ce";
                    BackgroundColor3 = "#1f99ce";
                    BackgroundColor4 = "#1f99ce";

                    OnPropertyChanged("BackgroundColor1");
                    OnPropertyChanged("BackgroundColor2");
                    OnPropertyChanged("BackgroundColor3");
                    OnPropertyChanged("BackgroundColor4");
                    Xrwma = Colorbutton.Button1;

                });

            }

        }


        public Command Button2
        {

            get
            {

                return new Command(() =>
                {
                    RefreshClass.Choice = 2;
                    BackgroundColor1 = "#1f99ce";
                    BackgroundColor2 = "Green";
                    BackgroundColor3 = "#1f99ce";
                    BackgroundColor4 = "#1f99ce";

                    OnPropertyChanged("BackgroundColor1");
                    OnPropertyChanged("BackgroundColor2");
                    OnPropertyChanged("BackgroundColor3");
                    OnPropertyChanged("BackgroundColor4");
                    Xrwma = Colorbutton.Button2;

                });

            }

        }

        public Command Button3
        {

            get
            {

                return new Command(() =>
                {
                    RefreshClass.Choice = 3;

                    BackgroundColor1 = "#1f99ce";
                    BackgroundColor2 = "#1f99ce";
                    BackgroundColor3 = "Green";
                    BackgroundColor4 = "#1f99ce";

                    OnPropertyChanged("BackgroundColor1");
                    OnPropertyChanged("BackgroundColor2");
                    OnPropertyChanged("BackgroundColor3");
                    OnPropertyChanged("BackgroundColor4");
                    Xrwma = Colorbutton.Button3;

                });

            }

        }


        public Command Button4
        {

            get
            {

                return new Command(() =>
                {
                    RefreshClass.Choice = 4;

                    BackgroundColor1 = "#1f99ce";
                    BackgroundColor2 = "#1f99ce";
                    BackgroundColor3 = "#1f99ce";
                    BackgroundColor4 = "Green";

                    OnPropertyChanged("BackgroundColor1");
                    OnPropertyChanged("BackgroundColor2");
                    OnPropertyChanged("BackgroundColor3");
                    OnPropertyChanged("BackgroundColor4");
                    Xrwma = Colorbutton.Button4;

                });

            }

        }


//Κουμπιά διάταξης παραγγελιών (Properties):

        public int Hide_Delayed
        {
            get { return _hide_Delayed; }
            set
            {
                _hide_Delayed = value;
                OnPropertyChanged();
                Utils.Settings.LastHide_DelayedSettings = value.ToString();
            }
        }

        public bool Visibility
        {
            get { return _visibility; }

            set { _visibility = value; OnPropertyChanged(); }
        }


        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }

        public int Kds_Code
        {
            get { return _kds_Code; }
            set {
                _kds_Code = value;
                OnPropertyChanged();
                Utils.Settings.LastCodeUsedSettings = value.ToString();
            }
        }

        public string IpAddress
        {
            get { return _ipAddress; }
            set
            {
                _ipAddress = value;
                OnPropertyChanged();
                Utils.Settings.LastiPUsedSettings = value;

            }
        }

        public string Port
        {
            get { return _port; }
            set
            {
                _port = value;
                OnPropertyChanged();
                Utils.Settings.LastPortUsedSettings = value;
            }
        }

        public static int FlagVariable
        {
            get { return _flagVariable; }
            set { _flagVariable = value;  }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
