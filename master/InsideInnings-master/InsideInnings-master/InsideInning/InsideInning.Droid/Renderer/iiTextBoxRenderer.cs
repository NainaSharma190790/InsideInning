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
using InsideInning;
using InsideInning.Droid.Renderer;

[assembly: ExportRenderer(typeof(iiTextBox), typeof(iiTextBoxRenderer))]
namespace InsideInning.Droid.Renderer
{
    public class iiTextBoxRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(Control!=null)
            {
                Control.SetBackgroundResource(Resource.Drawable.iiTextBox);
                //SetCompoundDrawables(dr, null, null, null);
                switch (e.NewElement.ClassId)
                {
                    case "1":
                        Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.persons, 0, 0, 0);
                        break;
                    case "3":
                        Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.email, 0, 0, 0);
                        break;
                    case "4":
                        Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.password, 0, 0, 0);
                        break;
                    case "5":
                        Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.persons, 0, 0, 0);
                        break;
                    case "6":
                        Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.password, 0, 0, 0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
