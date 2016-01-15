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
    public class EmpDetailsViewPage : ContentPage
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
        public EmpDetailsViewPage(Employee emp ,EmployeeViewModel empViewModel)
        {
            ViewModel = empViewModel;
            ViewModel.EmployeeDetail = emp;
            BindingContext = ViewModel.EmployeeDetail;
            //ViewModel = viewModel; //Passed from List or Dashboard
            _EmployeeID = emp.EmployeeID;
            BackgroundImage = "back";
           // BindingContext = ViewModel.EmployeeDetail;
           // ViewModel.LoadEmpDetail.Execute(_EmployeeID);
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
                    { iiControls.CreateLabelFor("ContactNumber",Color.White)},
                    { iiControls.CreateLabelFor("EmailAddress",Color.White)},
                    { iiControls.CreateLabelFor("CompanyProfile",Color.White)}
                }
            };
            return customLayout;
        }
        
        #endregion

        #region Relative layout for coverpage and profile picture
        public StackLayout CreateRealtiveLayoutFor()
        {
            RelativeLayout MainView = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.Start,
                BackgroundColor = Xamarin.Forms.Color.Blue,
                Padding = new Thickness(1, 1, 1, 1),
                HeightRequest = 10,
            };
            var CoverPage = new iiImage { HorizontalOptions = LayoutOptions.CenterAndExpand };

            var CircleImage = new CircleImage
            {
                // BorderColor = Color.White.ToFormsColor(),
                // BorderThickness = 2,
                HorizontalOptions = LayoutOptions.Fill,

            };
            CircleImage.SetBinding(Image.SourceProperty, "EmpProfileImage");
            
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Console.WriteLine("Yes Clicked");
            };

            CircleImage.GestureRecognizers.Add(tapGestureRecognizer);
           

            MainView.Children.Add(CoverPage, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.RelativeToParent(parent => { return parent.Width; }),
                Constraint.RelativeToParent(parent => { return parent.Height; }));

            MainView.Children.Add(CircleImage, Constraint.Constant(0),
            Constraint.RelativeToView(CoverPage, (parent, sibling) => { return sibling.Height -50; }), Constraint.Constant(100), Constraint.Constant(100));

            var st = new StackLayout
            {
                HeightRequest=150,
                Children = { MainView }
            };
            return st;
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

            grid.Children.Add(iiControls.CreateLabelFor("FullName", Color.White), 0, 0);
            //grid.Children.Add(iiControls.CreateLabelFor("LastName", Color.White), 1, 0);
            var birthLabel = iiControls.CreateLabelFor("DateOfBirth", Color.White);
            birthLabel.SetBinding(Label.TextProperty, new Binding("DateOfBirth") { StringFormat = "{0:dd-MMM-yyyy}" });
            grid.Children.Add(birthLabel, 0, 1);
            var joinLabel = iiControls.CreateLabelFor("JoinningDate", Color.White);
            joinLabel.SetBinding(Label.TextProperty, new Binding("JoinningDate") { StringFormat = "{0:dd-MMM-yyyy}" });
            grid.Children.Add(joinLabel, 1, 1);

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
            
            //TODO : Have to get from local no more second API call
            ViewModel.LoadEmpDetail.Execute(_EmployeeID);
        }

        #endregion
        
    }
}
