using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using InsideInning.Pages;
using InsideInning.iOS.Renderer;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(iiImage), typeof(iiImageRenderer))]

namespace InsideInning.iOS.Renderer
{
    public class iiImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            Control.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("cover.png"));
        }
    }
}