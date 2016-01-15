using InsideInning.Helper;
using InsideInning.Models;
using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;

namespace InsideInning.Pages
{
    public class LeaveRequestViewPage : BaseViewPage
    {
        #region Type cast BindingContex 
        private LeaveRequestViewModel ViewModel
        {
            get { return new LeaveRequestViewModel(); } //Type cast BindingContex as HomeViewModel to access binded properties
        }
        #endregion

        #region Bind all contols in stack layout
        public LeaveRequestViewPage()
        {
            BackgroundImage = "back";
            BindingContext = new LeaveRequest();
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 50,
                Padding = new Thickness(30, 20, 30, 0),
                Children = 
                {
                    {(CreatePickerFor("LeaveType", LayoutOptions.FillAndExpand))},
                    {(CreateDatePickerFor("FromDate", LayoutOptions.FillAndExpand, "3"))},
                    {(CreateDatePickerFor("ToDate", LayoutOptions.FillAndExpand, "4"))},
                    {(CreateLabelFor("ApprovedDays", LayoutOptions.FillAndExpand,"1"))},
                    {CreateEditorFor("Notes", LayoutOptions.FillAndExpand,"1")},                       
                    new Button
                    {
                        Text="Send",TextColor=Color.White.ToFormsColor(),BackgroundColor=Color.Gray.ToFormsColor(),BorderWidth=1,HorizontalOptions=LayoutOptions.FillAndExpand,TranslationY=40,
                        HeightRequest=40,
                        Command=ViewModel.AddCommand, CommandParameter=(LeaveRequest)BindingContext
                    }    
                }
            };
        }
        #endregion

        #region Custom Label
        public View CreateLabelFor(string propertyName, LayoutOptions layout,string id ="")
        {
            iiLabel iiLabel = new iiLabel
            {
                TextColor = Color.White.ToFormsColor(),
                Text = propertyName,
                HorizontalOptions = layout,
                HeightRequest=45,
                FontSize=20,
                ClassId=id,
             };
            return iiLabel;
        }
        
        #endregion

        #region Custom DropDown
        public static View CreatePickerFor(string propertyName, LayoutOptions layout)
        {
            iiPicker iiPicker = new iiPicker
            {
                HorizontalOptions = layout,
                Title = "Leave Type",
                HeightRequest = 50,
                WidthRequest = 50,
                
            };
            iiPicker.Items.Add("Casual Leave");
            iiPicker.Items.Add("Medical Leave");
            iiPicker.Items.Add("Paid Leave");
            //iiPicker.SetBinding(Picker.TitleProperty, propertyName);
            iiPicker.SelectedIndex = 0;
            return iiPicker;
        }

        #endregion

        #region Custom Editor(EditText box for multiple line)
        public static View CreateEditorFor(string propertyName, LayoutOptions layout, string id = "")
        {
            iiEditor iiEditTextBox = new iiEditor
            {
                HorizontalOptions = layout,
                HeightRequest = 200,
                WidthRequest = 400,
                ClassId=id,

            };

            iiEditTextBox.SetBinding(Editor.TextProperty, propertyName);
            return iiEditTextBox;
        }
        #endregion

        #region Custom DatePicker
        public View CreateDatePickerFor(string propertyName, LayoutOptions layout, string id = "")
        {
            iiDatePicker iiDatePicker = new iiDatePicker
            {
                HorizontalOptions = layout,
                ClassId=id,
                //BackgroundColor = Helper.Color.iiGreen.ToFormsColor(),

            };
            iiDatePicker.SetBinding(DatePicker.DateProperty, propertyName);
            return iiDatePicker;
        }
        #endregion

        #region Custom Entry
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
        #endregion

    }
}


