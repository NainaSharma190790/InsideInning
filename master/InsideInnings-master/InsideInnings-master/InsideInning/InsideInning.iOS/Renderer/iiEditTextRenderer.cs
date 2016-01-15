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
[assembly: ExportRenderer(typeof(iiEditor), typeof(iiEditTextRenderer))]

namespace InsideInning.iOS.Renderer
{
    public class iiEditTextRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Layer.BorderColor = UIColor.White.CGColor;
                Control.Layer.BorderWidth = 1f;
                //Control.BorderStyle = UITextBorderStyle.Line;
                Control.Layer.CornerRadius = 0;
                Control.ClipsToBounds = true;
                if (e.NewElement.ClassId == "1")
                {
                    //Control.LeftView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("notes.png"));

                }
            }
        }
    }
}