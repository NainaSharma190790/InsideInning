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

[assembly: ExportRenderer(typeof(iiLabel), typeof(iiLabelRenderer))]
namespace InsideInning.Droid.Renderer
{
   public class iiLabelRenderer : LabelRenderer
    {
       protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
       {
           base.OnElementChanged(e);
           

           if (Control != null)
           {
               switch (e.NewElement.ClassId)
               {
                   case "1":
                       Control.SetBackgroundResource(Resource.Drawable.iiTextBox);
                       break;
                   case "2":
                       Control.SetBackgroundResource(Resource.Drawable.LeftTopCorner);
                       break;
                   case "3":
                       Control.SetBackgroundResource(Resource.Drawable.RigthTopCorner);
                       break;
                   default:
                       break;
               }
           }
       }   
    }
}