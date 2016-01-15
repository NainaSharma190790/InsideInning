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
using InsideInning.Droid.Renderer;
using InsideInning;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(iiListView), typeof(iiListViewRenderer))]

namespace InsideInning.Droid.Renderer
{
    class iiListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            
            if(Control!=null)
            {
                switch (e.NewElement.ClassId)
                {
                    case "1":
                        Control.SetBackgroundResource(Resource.Drawable.back);
                        Control.DividerHeight = 3;
                       //Control.Divider = new ColorDrawable(Android.Graphics.Color.Red);
                        break;
                    case "2":
                        Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                        Control.DividerHeight = 2;
                      //  Control.Divider = new ColorDrawable(Android.Graphics.Color.Red);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}