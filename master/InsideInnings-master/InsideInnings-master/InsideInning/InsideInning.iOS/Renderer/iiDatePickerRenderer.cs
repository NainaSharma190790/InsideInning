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
using CoreGraphics;

[assembly: ExportRenderer(typeof(iiDatePicker), typeof(iiDatePickerRenderer))]

namespace InsideInning.iOS.Renderer
{
	public class iiDatePickerRenderer : DatePickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);
			if (Control != null)
			{
				Control.Layer.BorderColor = UIColor.White.CGColor;
				Control.Layer.BorderWidth = 1f;
				Control.BorderStyle = UITextBorderStyle.Line;
				Control.Layer.CornerRadius = 0;
				Control.ClipsToBounds = true;
				var imageView = new UIImageView(new CGRect(0, 0, 50, 50));

				switch (e.NewElement.ClassId)//Set icon on datepicker through Id
				{
					case "1":
						imageView.Image = UIImage.FromFile("Birthday.png");
						Control.LeftView = imageView;
                        //SetCompoundDrawablesRelativeWithIntrinsicBounds(Resource.Drawable.Birthday, 0, 0, 0);
						break;
					case "2":
						imageView.Image = UIImage.FromFile("Joinning.png");
						Control.LeftView = imageView;
						break;
					case "3":
						imageView.Image = UIImage.FromFile("ToDate.png");
						Control.LeftView = imageView;
						break;
					case "4":
						imageView.Image = UIImage.FromFile("FromDate.png");
						Control.LeftView = imageView;
						break;
					default:
						break;
				}
			}
		}
	}
}