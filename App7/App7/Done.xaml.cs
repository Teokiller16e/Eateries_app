using App7.Services;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Done : ContentPage
    {
        public static  Done_ViewModel viewModel { get; set; }
     
        public Done()
        {

            InitializeComponent();
            viewModel = new Done_ViewModel();
            BindingContext = viewModel;

            
         
            
        }

        private async void ToolbarItem_Clicked_3(object sender, EventArgs e)
        {

            //await App.Current.MainPage.Navigation.PopAsync();
            GC.Collect();
            await Navigation.PopToRootAsync();
            
            //  var mainpage = new MainPage();
            // await Navigation.PushAsync(mainpage);           

        }

  

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {

            if (RefreshClass.Options_Choice == false)
            {
                RefreshClass.Options_Choice = true;
                await Navigation.PushPopupAsync(new Test_Settings());
            }

        }


    }
}