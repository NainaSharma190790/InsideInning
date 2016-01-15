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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using InsideInning;
using InsideInning.Droid.Renderer;


[assembly: ExportRenderer(typeof(iiPicker), typeof(iiPickerRenderer))]
namespace InsideInning.Droid.Renderer
{
   public class iiPickerRenderer : PickerRenderer
    {
       protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
       {
           base.OnElementChanged(e);
           if(Control!=null)
           {
               Control.SetBackgroundResource(Resource.Drawable.iiTextBox);

           }
       }
    }
}