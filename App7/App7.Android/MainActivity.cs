using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace App7.Droid
{
    [Activity(Label = "Prepare", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true,
       ScreenOrientation = ScreenOrientation.Landscape , ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            UserDialogs.Init(this);

         //   Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}

