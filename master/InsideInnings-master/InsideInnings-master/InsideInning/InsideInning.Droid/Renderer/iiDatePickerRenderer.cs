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
[assembly: ExportRenderer(typeof(iiDatePicker), typeof(iiDatePickerRenderer))]
namespace InsideInning.Droid.Renderer
{
    public class iiDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.iiTextBox);
                switch (e.NewElement.ClassId)//Set icon on datepicker through Id
                {
                    case "1":
                       // Control.LeftView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Birthday.png"));
                       break;
                    case "2":
                      // Control.LeftView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Joinning.png"));
                        break;
                    case "3":
                       // Control.LeftView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("ToDate.png"));
                        break;
                    case "4":
                        //Control.LeftView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("FromDate.png"));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}