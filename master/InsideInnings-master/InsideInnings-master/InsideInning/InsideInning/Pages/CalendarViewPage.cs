using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.iiCalendar;
using Color = InsideInning.Helper.Color;



namespace InsideInning.Pages
{
    public class CalendarViewPage : BaseViewPage
    {

        CalendarView _calendarView;
        StackLayout _stacker;

        public CalendarViewPage()
        {
            Title = "Calendar View";

            _stacker = new StackLayout();
            Content = _stacker;

            _calendarView = new CalendarView()
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            _stacker.Children.Add(_calendarView);
            _calendarView.DateSelected += (object sender, DateTime e) =>
            {
                if (_stacker.Children.Count > 1)
                    _stacker.Children.RemoveAt(1);
                _stacker.Children.Add(GenTabGrid());
            };
        }

        private Grid GenTabGrid()
        {
            int i = 5;
            var grid = new Grid()
            {
                ColumnSpacing = 2,
                RowSpacing = 2,
                Padding = new Thickness(10, 0, 10, 0),

            };

            grid.Children.Add(CreateLabelFor("Employee Name", LayoutOptions.Start, "2"), 0, 0);
            grid.Children.Add(CreateLabelFor("Designation", Color.Purple, LayoutOptions.Start, "", true), 1, 0);
            grid.Children.Add(CreateLabelFor("From", Color.Purple, LayoutOptions.Start, "", true), 2, 0);
            grid.Children.Add(CreateLabelFor("To", LayoutOptions.Start, "3"), 3, 0);
            for (int j = 1; j <= i; j++)
            {
                grid.Children.Add(CreateLabelFor("Neha", Color.Purple, LayoutOptions.Start, "", true), 0, j);
                grid.Children.Add(CreateLabelFor("S/w Dev", Color.White, LayoutOptions.Start), 1, j);
                grid.Children.Add(CreateLabelFor("11/02/15", Color.White, LayoutOptions.Start), 2, j);
                grid.Children.Add(CreateLabelFor("15/02/15", Color.White, LayoutOptions.Start), 3, j);
            }
            return grid;
        }
        #region Custom Label
        public View CreateLabelFor(string propertyName, Color color, LayoutOptions layout, string id = "", bool isHeader = false)
        {
            iiLabel iiLabel = new iiLabel
            {

                TextColor = isHeader ? Color.White.ToFormsColor() : Color.DarkBlue.ToFormsColor(),
                Text = propertyName,
                HorizontalOptions = layout,
                HeightRequest = 25,
                WidthRequest = 130,
                FontSize = 10,
                ClassId = id,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                BackgroundColor = color.ToFormsColor(),
            };
            return iiLabel;
        }
        public View CreateLabelFor(string propertyName, LayoutOptions layout, string id = "")
        {
            iiLabel iiLabel = new iiLabel
            {
                TextColor = Color.White.ToFormsColor(),
                Text = propertyName,
                HorizontalOptions = layout,
                HeightRequest = 25,
                WidthRequest = 120,
                FontSize = 10,
                ClassId = id,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };
            return iiLabel;
        }
        #endregion
    }
}

  