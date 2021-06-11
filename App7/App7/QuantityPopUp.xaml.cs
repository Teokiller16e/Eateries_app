using App7.CustomListView;
using App7.Model;
using App7.Services;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuantityPopUp : PopupPage
    {

        public KDSService kds_Service { get; set; }
        public int max_limit { get; set; }

        public SelectableItem<Viewitem>test_item {get;set;}
        public  QuantityPopUp()
        {
            kds_Service = new KDSService();

            MessagingCenter.Subscribe<PendingViewModel,SelectableItem<Viewitem>>(this, "Questions", (page, item) =>
            {
                test_item = new SelectableItem<Viewitem>();
                test_item = item;

                max_limit = (int)item.Data.Quantity;
                NameLabel.Text = "Πόσα από " + item.Data.Productname + " :";
                QuantityEntry.Text = max_limit.ToString();

            });

            InitializeComponent();

        }



        private async void  Done_Button_Clicked(object sender, System.EventArgs e)
        {
            int num;
            num = Convert.ToInt32(QuantityEntry.Text);

            if (num<=max_limit && num>=1)
            {
                kds_Service.OrderItemDelivered(test_item.Data.Order_item_id, true, Convert.ToInt32(QuantityEntry.Text));
            }
            
            await Navigation.PopPopupAsync();
            RefreshClass.Next_PopUp = true;

            //  await MainPage.viewModel.InitializeAsync(RefreshClass.Choice);
        }


        private void Add_Quantity(object sender, System.EventArgs e)
        {
            int plus;
            plus = Convert.ToInt32(QuantityEntry.Text); 
            //Προσθέτουμε προιόντα εδώ
            if(plus<max_limit && plus>=1)
            {
                plus++;
                QuantityEntry.Text = plus.ToString();
            }
          
        }


        private void Minus_Quantity(object sender, System.EventArgs e)
        {
            int minus;
            minus = Convert.ToInt32(QuantityEntry.Text);
            //Αφαιρούμε προιόντα εδώ
            if (minus <= max_limit && minus >1)
            {
                minus--;
                QuantityEntry.Text = minus.ToString();
            }
        }


    }
}