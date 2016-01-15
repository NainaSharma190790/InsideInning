using InsideInning.Helper;
using InsideInning.Models;
using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;
using ImageCircle.Forms.Plugin.Abstractions;

namespace InsideInning.Pages
{
    public class EmployeeDetailsPage : ContentPage
    {
        Int32 _EmployeeID;

        #region Access binded properties
        private EmployeeViewModel ViewModel
        {
            get;
            set;//Type cast BindingContex as HomeViewModel to access binded properties
        }        
        #endregion

        #region Main stack Layout
        public EmployeeDetailsPage(Int32 _id, EmployeeViewModel _viewModel)
        {
            ViewModel = _viewModel; //Passed from List or Dashboard
            _EmployeeID = _id;
            BackgroundImage = "back";
            BindingContext = ViewModel.EmployeeDetail;
            ViewModel.LoadEmpDetail.Execute(_EmployeeID);
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 10,
                Padding = new Thickness(0, 0, 0, 0),
                Children = 
                {
                    {CreateRealtiveLayoutFor()},
                    Layout(),
                }
            };
        }       
        #endregion

        #region Stacklayout with Spacing
        private StackLayout Layout()
        {
            var customLayout = new StackLayout
            {
                BackgroundColor = Xamarin.Forms.Color.Transparent,
                Padding = new Thickness(30, 60, 30, 0),
                Spacing = 7,

                Children =
                {
                    GenGrid(),
                    { iiControls.CreateEntryFor("ContactNumber",Color.White)},
                    { iiControls.CreateEntryFor("EmailAddress",Color.White)},
                    { iiControls.CreateEntryFor("CompanyProfile",Color.White)},
                    new Button 
                    {
                        Text= "Submit",
                        TextColor=Color.LightRed.ToFormsColor(),
                        BackgroundColor=Color.LightGreen.ToFormsColor(),
                        Command=ViewModel.AddUpdateEmployeeDetailsCommand,
                        CommandParameter=(EmployeeDetails)BindingContext,
                        HorizontalOptions=LayoutOptions.FillAndExpand
                    },
                }
            };
            return customLayout;
        }
        
        #endregion

        #region Relative layout for coverpage and profile picture
        public RelativeLayout CreateRealtiveLayoutFor()
        {
            RelativeLayout MainView = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Xamarin.Forms.Color.Transparent,
                Padding = new Thickness(1, 1, 1, 1),
                HeightRequest = 10,

            };
            var CoverPage = new iiImage { VerticalOptions = LayoutOptions.FillAndExpand};

            var CircleImage = new CircleImage
            {
                Source = ViewModel.ImageSource,
                BorderColor = Color.White.ToFormsColor(),
                BorderThickness = 2,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            
            
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
               ViewModel.SelectPictureCommand.Execute(null);
            };

            CircleImage.GestureRecognizers.Add(tapGestureRecognizer);
            //CircleImage.SetBinding(Image.SourceProperty, "ImageSource");

            MainView.Children.Add(CoverPage, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent(parent => { return parent.Width; }),
                Constraint.RelativeToParent(parent => { return parent.Height; }));

            MainView.Children.Add(CircleImage, Constraint.Constant(0),
            Constraint.RelativeToView(CoverPage, (parent, sibling) => { return sibling.Height -50; }), Constraint.Constant(100), Constraint.Constant(100));

            return MainView;
        }

        #endregion

        #region Custom control for main layout
        private Grid GenGrid()
        {
            var grid = new Grid
            {
                Padding = new Thickness(0, -10, 0, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                ColumnSpacing = 5,
                RowSpacing = 10,

            };

            grid.Children.Add(iiControls.CreateEntryFor("First Name", Color.White), 0, 0);
            grid.Children.Add(iiControls.CreateEntryFor("Last Name", Color.White), 1, 0);

            grid.Children.Add(CreateDatePickerFor("Date of birth", "DateOfBirth", "1"), 0, 1);
            grid.Children.Add(CreateDatePickerFor("Date of Joining", "JoinningDate", "2"), 1, 1);

            return grid;
        }
        public View CreateButtonFor(string propertyName, LayoutOptions layout, string id = "")
        {

            iiButton iiButton = new iiButton
            {
                //HorizontalOptions = LayoutOptions.FillAndExpand,
                // Image=(FileImageSource)ImageSource.FromFile(imgscr),
                BackgroundColor = Xamarin.Forms.Color.Transparent,
                BorderColor = Xamarin.Forms.Color.White,
                BorderWidth = 2,
                WidthRequest = 70,
                HeightRequest = 40,
                HorizontalOptions = layout,
                ClassId = id,
            };
            //iiButton.SetBinding(Button.TextColorProperty, propertyName);
            return iiButton;
        }
        public View CreateDatePickerFor(string propertyName, string bindProperty, string id = "")
        {
            iiDatePicker iiDatePicker = new iiDatePicker
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Xamarin.Forms.Color.Transparent,
                //Color.iiEditTextColor.ToFormsColor(),
                ClassId = id,

            };
            iiDatePicker.SetBinding(iiDatePicker.DateProperty, bindProperty);
            return iiDatePicker;
        } 
        #endregion

        #region Load employee deatil
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            ViewModel.LoadEmpDetail.Execute(_EmployeeID);
        }

        #endregion
        
    }

    public class iiImage :Image
    {

    }
}