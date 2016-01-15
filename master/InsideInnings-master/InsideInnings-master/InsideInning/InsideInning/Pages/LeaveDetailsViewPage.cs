using InsideInning.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;

namespace InsideInning.Pages
{
    public class LeaveDetailsViewPage : BaseViewPage
    {
        public LeaveDetailsViewPage()
        {
            Content = new StackLayout
            {
                // HorizontalOptions = LayoutOptions.FillAndExpand,
                //HeightRequest = 50,
                BackgroundColor = Color.iiGreen.ToFormsColor(),
                Padding = new Thickness(10, 10, 10, 10),
                Children = 
                {
                    GenCalGrid(),
                    {iiControls. CreateEntryFor("To",Color.White)},
                    {CreateLabelFor("Notes", LayoutOptions.Start)},
                    {CreateEditorFor("Notes", LayoutOptions.Start)},                       
                    {CreateButtonFor ("SEND",Color.iiPurple,LayoutOptions.Center)}
                }
            };
        }
        private Grid GenCalGrid()
        {
            var grid = new Grid()
            {
                HeightRequest = 200,
            };

            grid.Children.Add(CreateLabelFor("From Date", LayoutOptions.Center), 0, 0);
            grid.Children.Add(CreateDatePickerFor("From Date", LayoutOptions.Center), 0, 1);

            grid.Children.Add(CreateLabelFor("To Date", LayoutOptions.Center), 1, 0);
            grid.Children.Add(CreateDatePickerFor("To Date", LayoutOptions.Center), 1, 1);

            grid.Children.Add(CreateEntryFor("No. of days", Color.White, LayoutOptions.Center), 0, 2);
            grid.Children.Add(CreatePickerFor("Laeve Type", LayoutOptions.Start), 1, 2);

            return grid;
        }
        public View CreateLabelFor(string propertyName, LayoutOptions layout)
        {
            Label iiLabel = new Label
            {
                TextColor = Color.White.ToFormsColor(),
                Text = propertyName,
                YAlign = TextAlignment.Center,
                HorizontalOptions = layout,

            };
            return iiLabel;
        }
        public View CreateDatePickerFor(string propertyName, LayoutOptions layout)
        {
            DatePicker iiDatePicker = new DatePicker
            {
                HorizontalOptions = layout,
                BackgroundColor = Helper.Color.iiGreen.ToFormsColor(),

            };
            iiDatePicker.SetBinding(DatePicker.DateProperty, propertyName);
            return iiDatePicker;
        }
        public View CreateButtonFor(string propertyName, Color color, LayoutOptions layout)
        {
            Button iiButton = new Button
            {
                //HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = color.ToFormsColor(),
                Text = "Send",
                BorderWidth = 10,
                WidthRequest = 100,
                HeightRequest = 50,
                HorizontalOptions = layout,
            };
            iiButton.SetBinding(Button.TextColorProperty, propertyName);
            return iiButton;
        }
        public static View CreateEditorFor(string propertyName, LayoutOptions layout)
        {
            Editor iiEditTextBox = new Editor
            {
                HorizontalOptions = layout,
                BackgroundColor = Helper.Color.iiPurple.ToFormsColor(),
                HeightRequest = 200,
                WidthRequest = 400,

            };

            iiEditTextBox.SetBinding(Editor.TextProperty, propertyName);
            return iiEditTextBox;
        }
        public static View CreateEntryFor(string propertyName, Color color, LayoutOptions layout)
        {
            Entry iiEditTextBox = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = color.ToFormsColor(),
                Placeholder = propertyName,
                HeightRequest = 300,

            };
            iiEditTextBox.SetBinding(Entry.TextProperty, propertyName);
            return iiEditTextBox;
        }
        public static View CreatePickerFor(string propertyName, LayoutOptions layout)
        {
            Picker iiPicker = new Picker
            {
                HorizontalOptions = layout,
                Title = "Leave Type",
                HeightRequest = 150,
                WidthRequest = 150,
            };
            iiPicker.Items.Add("Leave Type");
            iiPicker.Items.Add("Casual Leave");
            iiPicker.Items.Add("Medical Leave");
            iiPicker.Items.Add("Paid Leave");
            iiPicker.SetBinding(Picker.TitleProperty, propertyName);
            iiPicker.SelectedIndex = 0;
            return iiPicker;
        }
    }
}


