using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EncryptoBot_Proj
{
    [Activity(Label = "EncryptoBot", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash", Icon = "@drawable/keywords")]
    public class SplashScreen_Actv : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            Thread.Sleep(200);
            StartActivity(typeof(MainActivity));
        }
    }
}