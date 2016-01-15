using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace InsideInning.Helper
{
    public class iiControls
    {
        public static View CreateEntryFor(string propertyName, Color color, string id="", bool IsPassword = false)
        {
            iiTextBox iiEditTextBox = new iiTextBox
            {
                TextColor = color.ToFormsColor(),
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
        public static View CreateLabelFor(string propertyName, Color color, string id = "", bool IsPassword = false)
        {
            iiLabel iiLabel = new iiLabel
            {
                TextColor = color.ToFormsColor(),
                BackgroundColor = Xamarin.Forms.Color.Transparent, //Color.iiEditTextColor.ToFormsColor(),
                ClassId = id,
                TranslationY = 2,
            };
            iiLabel.HorizontalOptions = LayoutOptions.FillAndExpand;
            iiLabel.SetBinding(iiLabel.TextProperty, propertyName);
            return iiLabel;
        }

    }
}
