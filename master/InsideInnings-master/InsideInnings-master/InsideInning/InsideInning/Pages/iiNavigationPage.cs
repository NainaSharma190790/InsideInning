using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InsideInning.Pages
{
    public class iiNavigationPage : NavigationPage
    {
        public iiNavigationPage(Page page) : base(page)
        {
            BarBackgroundColor = InsideInning.Helper.Color.LightRed.ToFormsColor();
        }
    }
}
