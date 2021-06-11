using System;
using App7.Model;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;

namespace App7.CustomListView
{
    public static class MultiSelectListView
    {
        //Φτιάχνουμε το property εδώ προς το παρόν :
     


   


        //Bindable Property For MultiSelecting :P 
        public static readonly BindableProperty IsMultiSelectProperty =
            BindableProperty.CreateAttached("IsMultiSelect", typeof(bool), typeof(ListView), false, propertyChanged: OnIsMultiSelectChanged);

        public static bool GetIsMultiSelect(BindableObject view) => (bool)view.GetValue(IsMultiSelectProperty);
        public static void SetIsMultiSelect(BindableObject view, bool value) => view.SetValue(IsMultiSelectProperty, value);



      

        //Εδώ είναι το function για το multi selection της  listview :
        private static void OnIsMultiSelectChanged(BindableObject bindable, object oldValue, object newValue)
        {

            var listView = bindable as ListView;
          

            if (listView != null)
            {
                // always remove event
                listView.ItemSelected -= OnItemSelected;

                // add the event if true
                if (true.Equals(newValue))
                {
                    listView.ItemSelected += OnItemSelected;
                }
            }

        }


        public static void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            var item = e.SelectedItem as SelectableItem<Viewitem>;
    
            if (item != null)
            {

                App._timer.Stop();
                App._timer.Start();

                if(item.Data.IsCanceled == true)
                {
                    item.IsSelected = item.IsSelected;

                     
                }

                else
                {
                     //Εδώ πέρα δοκιμάσαμε να δούμε εάν το multiselect δουλεύει σωστά 

                    item.IsSelected = !item.IsSelected;

                }
                                          
            }
            // deselect the item
            ((ListView)sender).SelectedItem = null;

        }
    }
}
