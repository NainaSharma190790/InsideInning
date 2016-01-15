using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using InsideInning.Pages;
using InsideInning.Droid.Renderer;

[assembly: ExportRenderer(typeof(iiImage), typeof(iiImageRenderer))]
namespace InsideInning.Droid.Renderer
{
    public class iiImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            Control.SetBackgroundResource(Resource.Drawable.cover);
        }
    }
}