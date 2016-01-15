using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using InsideInning;
using InsideInning.iOS.Renderer;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(iiLabel), typeof(iiLabelRenderer))]
namespace InsideInning.iOS.Renderer
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
                        Control.Layer.BorderColor = UIColor.White.CGColor;
                        Control.Layer.BorderWidth = 1f;
                        //Control.BorderStyle = UITextBorderStyle.Line;
                        Control.Layer.CornerRadius = 0;
                        Control.ClipsToBounds = true; break;
                    case "2":
                        //Control.SetBackgroundResource(Resource.Drawable.LeftTopCorner);
                        break;
                    case "3":
                        // Control.SetBackgroundResource(Resource.Drawable.RigthTopCorner);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}