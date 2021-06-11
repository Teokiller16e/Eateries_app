using Plugin.Settings;
using Plugin.Settings.Abstractions;


namespace App7.Utils
{
    public static class Settings
    {
     
        #region Settings Constants

        //ip
        public const string LastIpSettingsKey = "latest_ip_address";
        private static readonly string SettingsIpDefault = "192.168.1.14";

        //port
        public const string LastPortSettingsKey = "latest_port_address";
        private static readonly string SettingsPortDefault = "8080";

        //Code
        public const string LastCodeSettingKey = "latest_Kds_Code";
        private static readonly string SettingsCodeDefault = "5";

        //Refresh Class Order5
        public const string LastChoiceSettingKey = "latest_Order_Choice";
        private static readonly string SettingsChoiceDefault = "1";

        //Hide_Delayed
        public const string LastHide_DelayedSettingKey = "latest_Hide_Delayed";
        private static readonly string SettingsHide_DelayedDefault = "100";

        #endregion

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

       
        //ip addresses :
        public static string LastiPUsedSettings
        {

            get
            {           
                return AppSettings.GetValueOrDefault(LastIpSettingsKey, SettingsIpDefault);               
            }

            set
            {
                AppSettings.AddOrUpdateValue(LastIpSettingsKey, value);
            }

        }

        //Port numbers :
        public static string LastPortUsedSettings
        {

            get
            {
              
                return AppSettings.GetValueOrDefault(LastPortSettingsKey, SettingsPortDefault);

            }

            set
            {
                AppSettings.AddOrUpdateValue(LastPortSettingsKey, value);
            }

        }

        
        //Kds_Code :
        public static string LastCodeUsedSettings
        {

            get
            {
               
                return AppSettings.GetValueOrDefault(LastCodeSettingKey, SettingsCodeDefault);

            }

            set
            {
                AppSettings.AddOrUpdateValue(LastCodeSettingKey, value);
            }

        }

        //RefreshClass Choice :
        public static string LastChoiceUsedSettings
        {

            get
            {
         
                return AppSettings.GetValueOrDefault(LastChoiceSettingKey, SettingsChoiceDefault);

            }

            set
            {
                AppSettings.AddOrUpdateValue(LastChoiceSettingKey, value);
            }

        }

        // BaseClass Hide_Delayed Μεταβλητή :
       public static string LastHide_DelayedSettings
        {

            get { return AppSettings.GetValueOrDefault(LastHide_DelayedSettingKey, SettingsHide_DelayedDefault); }

            set { AppSettings.AddOrUpdateValue(LastHide_DelayedSettingKey, value); }

        }

    }
}
