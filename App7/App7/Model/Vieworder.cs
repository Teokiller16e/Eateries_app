using App7.CustomListView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App7.Model
{
    public class Vieworder : INotifyPropertyChanged
    {

        private double _timeLeft;
        private string _orderTime;
        public int Dailyid { get; set; }
        public string Staffname { get; set; }
        public string Tablename { get; set; }
        public DateTime? Last_Placed { get; set; }
        public bool Done { get; set; }
        public string OrderCustomComment { get; set; }
        public IList<SelectableItem<Viewitem>> Items { get; set; }
        public bool IsCompleted { get; set; }

        //Εδώ θα βάλουμε μια μεταβλητή η οποία θα δείχνει τον χρόνο που έχει χτυπηθεί η παραγγελία
        // και για να το δείξουμε αυτό θα πρέπει να χρησιμοποιήσουμε την μεταβλητή Last_Placed
        public double TimeLeft
        {
            get { return _timeLeft; }
            set { _timeLeft = value; OnPropertyChanged(); }
        }

        public string OrderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
