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

[assembly: ExportRenderer(typeof(iiListView), typeof(iiListViewRenderer))]

namespace InsideInning.iOS.Renderer
{
	public class iiListViewRenderer : ListViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);
			Control.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("back.png"));
		}
	}
}