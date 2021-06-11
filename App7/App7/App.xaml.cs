
using App7.Model;
using App7.Services;
using App7.ViewModel;
using DLToolkit.Forms.Controls;
using DLToolkit.Forms.Controls.Helpers.FlowListView;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace App7
{
    [Preserve(AllMembers = true)]
    public partial class App : Application
    {     
        public KDSService kDSService { get; set; }

        public static Timer _timer;

        public App()
        {           
            InitializeComponent();
            
           // FlowListView.Init();

            kDSService = new KDSService();

            RefreshClass.Choice = Convert.ToInt32 (Utils.Settings.LastChoiceUsedSettings);

            BaseService.BaseIp = Utils.Settings.LastiPUsedSettings;

            BaseService.BasePort = Utils.Settings.LastPortUsedSettings;

            BaseService.Kds_Code = Convert.ToInt32 (Utils.Settings.LastCodeUsedSettings);

            BaseService.BaseStatus = "Checking for Connection...";

            BaseService.Hide_Delayed = Convert.ToInt32(Utils.Settings.LastHide_DelayedSettings);

            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromRgb(89, 89, 89)
                
                
            };
            _timer = new Timer(TimeSpan.FromSeconds(15), CountDown);
            //_timer.Start();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }
        private void CountDown()
        {

            if (SettingsViewModel.FlagVariable == 1)
            {
                MessagingCenter.Send<App>(this, "InitializePending");
                
            }
            else if (SettingsViewModel.FlagVariable == 2)
            {
                MessagingCenter.Send<App>(this, "InitializeDone");
             
            }

        }
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
