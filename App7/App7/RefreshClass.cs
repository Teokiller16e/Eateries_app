using System.Threading.Tasks;

namespace App7
{
    public static class RefreshClass
    {
        public static bool Options_Choice;
        private static int _choice;
        public static bool Next_PopUp;
        public static int Previous_Order_Id { get; set; }

        public static int Choice
        {
            get { return _choice; }

            set {
                _choice = value;
                Utils.Settings.LastChoiceUsedSettings = value.ToString();
            }
        }
    }
}
