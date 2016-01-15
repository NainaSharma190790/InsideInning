using InsideInning.Helper;
using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;

namespace InsideInning.Pages
{
    public class AddEmployeeViewPage : BaseViewPage
    {
        private EmployeeViewModel ViewModel
        {
            get { return new EmployeeViewModel(); } //Type cast BindingContex as HomeViewModel to access binded properties
        }

        public AddEmployeeViewPage()
        {
            BindingContext = new Employee();
            BackgroundImage = "back";
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(30, 0, 30, 0),
                Spacing=5,
                
                Children = 
                {
                    new Image{Source="ProfilePicture.jpg",Aspect=Aspect.Fill},
                    GenGrid(),
                    {iiControls.CreateEntryFor("EmailAddress",Color.iiTextColor,"3")},
                    {iiControls.CreateEntryFor("Password",Color.iiTextColor, "4", true)},
                   // {iiControls.CreateEntryFor("ConfirmPassword",Color.White,true)},
                    GenGridForSwitch(),
                    new Button
                    {
                        Text="Submit",TextColor=Color.LightRed.ToFormsColor(),BackgroundColor=Color.LightGreen.ToFormsColor(),BorderWidth=2,HorizontalOptions=LayoutOptions.Center,TranslationY=40,
                        HeightRequest=40,
                        WidthRequest=100,
                        Command=ViewModel.AddUpdateCommand, CommandParameter=(Employee)BindingContext
                    }                   
                }
            };
        }
        private Grid GenGrid()
        {
            var grid = new Grid()
            {
                RowSpacing=5,
                ColumnSpacing=5
                
            };
            grid.Children.Add(iiControls.CreateEntryFor("FirstName", Color.White,"1"), 0, 0);
            grid.Children.Add(iiControls.CreateEntryFor("LastName", Color.White,"2"), 1, 0);
            return grid;
        }
        private Grid GenGridForSwitch()
        {
            var _switchGrid = new Grid();            
            _switchGrid.Children.Add(new Label { Text = "Admin", TextColor = Color.White.ToFormsColor(),FontSize=20,BackgroundColor=Xamarin.Forms.Color.Transparent, HorizontalOptions = LayoutOptions.Start, TranslationX = 0, TranslationY = 5 }, 0, 0);
            _switchGrid.Children.Add(new Switch { HorizontalOptions = LayoutOptions.End  }, 1, 0);
            _switchGrid.Children.Add(new Label { Text = "Active", TextColor = Color.White.ToFormsColor(), FontSize = 20, BackgroundColor = Xamarin.Forms.Color.Transparent, HorizontalOptions = LayoutOptions.Start, TranslationX = 0, TranslationY = 5 }, 0, 1);
            _switchGrid.Children.Add(new Switch { HorizontalOptions = LayoutOptions.End }, 1, 1);
            return _switchGrid;
        }
    }
}
