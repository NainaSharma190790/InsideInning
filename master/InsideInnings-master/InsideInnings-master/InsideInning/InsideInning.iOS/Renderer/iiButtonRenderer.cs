using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using InsideInning.iOS.Renderer;
using InsideInning;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(iiButton), typeof(iiButtonRenderer))]
namespace InsideInning.iOS.Renderer
{
    public class iiButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                switch (e.NewElement.ClassId)
                {
                    case "1":
                       // Control.SetBackgroundImage(UIImage.FromFile("SelectedFemale.png"), UIControlState.Normal);
                        break;
                    case "2":
                        //Control.SetBackgroundImage(UIImage.FromFile("UnselectedMale.png"), UIControlState.Normal);
                        break;
                    case "3":
                        //Control.SetBackgroundImage(UIImage.FromFile("UnselectedMale.png"), UIControlState.Normal);
                        break;
                    case "4":
                       // Control.SetBackgroundImage(UIImage.FromFile("UnselectedMale.png"), UIControlState.Normal);
                        break;
                    case "5":
                       // Control.SetBackgroundImage(UIImage.FromFile("UnselectedMale.png"), UIControlState.Normal);
                        break;
                    case "6":
                        //Control.SetBackgroundImage(UIImage.FromFile("UnselectedMale.png"), UIControlState.Normal);
                        break;
                    case "7":
                       // Control.SetBackgroundImage(UIImage.FromFile("UnselectedMale.png"), UIControlState.Normal);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}