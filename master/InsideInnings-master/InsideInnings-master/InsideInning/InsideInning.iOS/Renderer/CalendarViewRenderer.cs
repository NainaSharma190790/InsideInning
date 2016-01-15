using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.iiCalendar;
using Xamarin.Forms.iiCalendar.iOS;
using escoz;

[assembly: ExportRenderer (typeof (CalendarView), typeof (CalendarViewRenderer))]

namespace Xamarin.Forms.iiCalendar.iOS
{
	public class CalendarViewRenderer : ViewRenderer<CalendarView, UIView> 
	{
		CalendarView _view;
		public CalendarViewRenderer ()
		{
		}

        #region OnElement Changed Method

        protected override void OnElementChanged(ElementChangedEventArgs<CalendarView> e)
        {
            _view = (CalendarView)e.NewElement;
            base.OnElementChanged(e);

            var calendarView = new CalendarMonthView(DateTime.Now, true);

            calendarView.OnDateSelected += (date) =>
            {
                _view.NotifyDateSelected(date);
            };

            base.SetNativeControl(calendarView);
        }

        #endregion
	}
}

