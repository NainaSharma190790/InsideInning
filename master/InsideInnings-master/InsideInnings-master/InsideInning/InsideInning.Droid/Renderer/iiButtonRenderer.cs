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
using InsideInning.Droid.Renderer;
using InsideInning;

[assembly: ExportRenderer(typeof(iiButton), typeof(iiButtonRenderer))]
namespace InsideInning.Droid.Renderer
{
   
    public class iiButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            if(Control!=null)
            {
                switch (e.NewElement.ClassId)
                {
                    case "1":
                       // Control.SetBackgroundResource(Resource.Drawable.iiMaleSelectionButton);
                        break;
                    case "2":
                      //  Control.SetBackgroundResource(Resource.Drawable.iiFemaleSelectionButton);     
                        break;
                    case "3":
                        Control.SetBackgroundResource(Resource.Drawable.iiTabBox);
                        break;
                    case "4":
                        Control.SetBackgroundResource(Resource.Drawable.iiTabBox);
                        break;
                    case "5":
                        Control.SetBackgroundResource(Resource.Drawable.iiTabBox);
                        break;
                    case "6":
                        //Control.SetBackgroundResource(Resource.Drawable.UnselectedMale);
                        break;
                    case "7":
                      //  Control.SetBackgroundResource(Resource.Drawable.UnselectedMale);
                        break;
                     default:
                        break;
                }
            }
        }
    }
}