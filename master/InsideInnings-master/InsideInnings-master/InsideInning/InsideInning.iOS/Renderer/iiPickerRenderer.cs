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

[assembly: ExportRenderer(typeof(iiPicker), typeof(iiPickerRenderer))]

namespace InsideInning.iOS.Renderer
{

    public class iiPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Layer.BorderColor = UIColor.White.CGColor;
                Control.Layer.BorderWidth = 1f;
                Control.BorderStyle = UITextBorderStyle.Line;
                Control.Layer.CornerRadius = 0;
                Control.ClipsToBounds = true;
            }
        }
    }
}