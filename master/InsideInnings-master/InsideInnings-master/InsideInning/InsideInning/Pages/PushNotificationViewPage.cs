using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Pages
{
    public class PushNotificationViewPage : BaseViewPage
    {
        public PushNotificationViewPage()
        {
            BackgroundImage = "back";
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 50,
                Padding = new Thickness(30, 20, 30, 0),
                Children = 
                {
                    {(CreateEntryFor("Title"))},
                    {(CreateEntryFor("Description"))},             
                    new Button
                    {
                        Text="Send",TextColor=Color.White.ToFormsColor(),BackgroundColor=Color.Gray.ToFormsColor(),BorderWidth=1,HorizontalOptions=LayoutOptions.FillAndExpand,TranslationY=40,
                        HeightRequest=40,//Command=ViewModel.AddCommand, CommandParameter=(LeaveRequest)BindingContext
                    }    
                }
            };
        }
        public static View CreateEntryFor(string propertyName, string id = "", bool IsPassword = false)
        {
            iiTextBox iiEditTextBox = new iiTextBox
            {
                TextColor = Xamarin.Forms.Color.Black,
                IsPassword = IsPassword,
                Placeholder = propertyName,
                BackgroundColor = Xamarin.Forms.Color.Transparent, //Color.iiEditTextColor.ToFormsColor(),
                ClassId = id,
                TranslationY = 2,
            };
            iiEditTextBox.HorizontalOptions = LayoutOptions.FillAndExpand;
            iiEditTextBox.SetBinding(iiTextBox.TextProperty, propertyName);
            return iiEditTextBox;
        }
    }
}
