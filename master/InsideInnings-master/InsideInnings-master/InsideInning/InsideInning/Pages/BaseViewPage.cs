using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InsideInning.Pages
{
    public class BaseViewPage : ContentPage
    {
        public BaseViewPage()
        {
            SetBinding(Page.TitleProperty, new Binding());
        }
        public enum TabView
        {
            Balance,
            Calendar,
            Holidays
        }
    }
}
