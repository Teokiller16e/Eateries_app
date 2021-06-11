using App7.CustomListView;
using App7.Services;
using Rg.Plugins.Popup.Extensions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    

    public partial class MainPage : ContentPage
	{
        public static PendingViewModel viewModel { get; set; }
      //  public TestSettings Settings;

        public MainPage()
        {

            InitializeComponent();
            viewModel = new PendingViewModel(Navigation);
            BindingContext = viewModel;


        }


        private async void ToolbarItem_Clicked_3(object sender, EventArgs e)
        {
            //await App.Current.MainPage.Navigation.PopAsync();
            GC.Collect();

            var done = new Done();
            await Navigation.PushAsync(done);
            
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