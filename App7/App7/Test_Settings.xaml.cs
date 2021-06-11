
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using App7.Services;
using App7.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test_Settings : PopupPage
    {

        public static Color SelectedColor { get; set; }
        public static Color UnselectedColor { get; set; }


        public Test_Settings()
        {
            //TestSlider.Value = Convert.ToInt32 (Utils.Settings.LastHide_DelayedSettings);
            //MainLabel.Text = Utils.Settings.LastHide_DelayedSettings.ToString();

            InitializeComponent();

            BindingContext = new SettingsViewModel();

        }


        protected override void OnDisappearing()
        {
            if (RefreshClass.Options_Choice == true)
            {

                RefreshClass.Options_Choice = false;

                if (SettingsViewModel.FlagVariable == 1)
                {
                    MessagingCenter.Send<Test_Settings>(this, "InitializePending");

                }

                else if (SettingsViewModel.FlagVariable == 2)
                {
                    MessagingCenter.Send<Test_Settings>(this, "InitializeDone");
                    MessagingCenter.Send<Test_Settings>(this, "InitializePending");
                }

            }
        }

        //Kds Code Entry Change
        private void Kds_Code_Entry_Completed(object sender, EventArgs e)
        {

            if (Kds.Text != "")
            {

                int code;
                Int32.TryParse(Kds.Text, out code);
                BaseService.Kds_Code = code;

            }

        }


        //Entry Action for Ip Address
        private void Ip_Entry_Completed(object sender, EventArgs e)
        {

            if (Ip.Text != "")
            {


                BaseService.BaseIp = Ip.Text;

            }

        }


        //Entry Action for Port
        private void Port_Entry_Completed(object sender, EventArgs e)
        {

            if (Port.Text != "")
            {
                BaseService.BasePort = Port.Text;
            }

        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int sliderprice = Convert.ToInt32(TestSlider.Value);
            MainLabel.Text = sliderprice.ToString() ;

            BaseService.Hide_Delayed = sliderprice;
        }

        /*
        private void Hide_Delayed_Completed(object sender, EventArgs e)
        {
            if(Hide_Delayed.Text != "")
            {
                int code;

                Int32.TryParse(Hide_Delayed.Text, out code);

                BaseService.Hide_Delayed = code;
            }
        }
        */
        
    }
}