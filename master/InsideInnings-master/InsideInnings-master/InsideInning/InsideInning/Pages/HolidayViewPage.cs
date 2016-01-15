using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;


namespace InsideInning.Pages
{
    public class HolidayViewPage : BaseViewPage
    {
        public HolidayViewPage()
        {
            BackgroundImage = "back";
            Content = new StackLayout
            {
                Padding = new Thickness(40, 70, 40, 20),
                Spacing = 2,
                HorizontalOptions = LayoutOptions.Center,
                Children = 
                {
                   GenEventTablelGrid(),
                }
            };
        }
        public View CreateGridLabelFor(string propertyName, Color color, LayoutOptions layout, string id = "", bool isHeader = false)
        {
            iiLabel iiLabel = new iiLabel
            {

                TextColor = Color.DarkBlue.ToFormsColor(),
                Text = propertyName,
                HorizontalOptions = layout,
                HeightRequest = 35,
                WidthRequest = 140,
                FontSize = 10,
                ClassId = id,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                BackgroundColor = color.ToFormsColor(),
            };
            return iiLabel;
        }

        private Grid GenEventTablelGrid()
        {
            int i = 5;
            var grid = new Grid()
            {
                ColumnSpacing = 2,
                RowSpacing = 2,
            };
            grid.Children.Add(CreateGridLabelFor("Event ", Color.Purple, LayoutOptions.Start, "", true), 0, 0);
            grid.Children.Add(CreateGridLabelFor("Details ", Color.Purple, LayoutOptions.Start, "", true), 1, 0);
            for (int j = 1; j <= i; j++)
            {
                grid.Children.Add(CreateGridLabelFor("Event {0}" + j, Color.Pink, LayoutOptions.Start, "", true), 0, j);
                grid.Children.Add(CreateGridLabelFor("Detail{0}" + j, Color.Pink, LayoutOptions.Start, "", true), 1, j);
            }
            return grid;
        }
    }
}

