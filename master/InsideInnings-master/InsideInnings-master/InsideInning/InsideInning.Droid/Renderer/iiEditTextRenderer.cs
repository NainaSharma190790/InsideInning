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
using InsideInning;
using InsideInning.Droid.Renderer;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(iiEditor), typeof(iiEditTextRenderer))]

namespace InsideInning.Droid.Renderer
{
   public class iiEditTextRenderer : EditorRenderer
    {
       protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
       {
           base.OnElementChanged(e);
           if (Control != null)
           {
               Control.SetBackgroundResource(Resource.Drawable.iiTextBox);
               if (e.NewElement.ClassId == "1")
               {
                   Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.Notes, 0, 0, 0);
               }
           }
       }
    }
}