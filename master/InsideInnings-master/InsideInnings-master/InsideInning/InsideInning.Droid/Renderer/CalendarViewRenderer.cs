using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xamarin.Forms.iiCalendar.Droid;
using Xamarin.Forms.iiCalendar;
using InsideInning.Droid;

[assembly: ExportRenderer(typeof(CalendarView), typeof(CalendarViewRenderer))]
namespace Xamarin.Forms.iiCalendar.Droid
{
    public class CalendarViewRenderer : ViewRenderer<CalendarView, Android.Views.ViewGroup>
    {

        #region Private Declaration

        private const string TAG = "Xamarin.Forms.Calendar";

        CalendarView _view;
        CalendarPickerView _pickerView;

        #endregion

        #region Element Change Method

        protected override void OnElementChanged(ElementChangedEventArgs<CalendarView> e)
        {
            _view = (CalendarView)e.NewElement;
            base.OnElementChanged(e);

            LayoutInflater inflatorservice = (LayoutInflater)Context.GetSystemService(Android.Content.Context.LayoutInflaterService);
            var containerView = (Android.Widget.LinearLayout)inflatorservice.Inflate(Resource.Layout.calendar_picker, null, false);

            _pickerView = containerView.FindViewById<CalendarPickerView>(Resource.Id.calendar_view);
            _pickerView.Init(new DateTime(2014, 6, 1), new DateTime(2014, 6, 30))
                .InMode(CalendarPickerView.SelectionMode.Single);

            _pickerView.OnDateSelected += (s, ew) =>
            {
                _view.NotifyDateSelected(ew.SelectedDate);
            };
            SetNativeControl(containerView);
        }

        #endregion
    }
}