using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

using ImageCircle.Forms.Plugin.Abstractions;
using XLabs.Ioc;
using XLabs.Platform.Services.Media;

namespace InsideInning.Droid
{
    [Activity(Icon = "@drawable/menuIcon", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //Forms.Init(this, bundle);
            //

            if (!Resolver.IsSet)
            {
                this.SetIoc();
            }
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new InsideInning.App());
        }

        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();
            resolverContainer.Register<IMediaPicker>(new MediaPicker());
            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
}

