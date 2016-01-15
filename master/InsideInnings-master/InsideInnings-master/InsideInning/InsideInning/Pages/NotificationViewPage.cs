using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;
using InsideInning.Models;

namespace InsideInning.Pages
{
    public class NotificationViewPage : ContentPage
    {
        private EmployeeViewModel ViewModel
        {
            get;
            set;//Type cast BindingContex as HomeViewModel to access binded properties
        }
        ListView _iiEmpList = null;
        public NotificationViewPage()
        {
            ViewModel = ViewModel ?? new EmployeeViewModel();
            ViewModel.LoadAllEmployees.Execute(null);
            _iiEmpList = new iiListView()
            {
                ItemTemplate = new DataTemplate(typeof(NotificationViewCell)),
                RowHeight = 80,
                ClassId = "1",
            };

            Content = new StackLayout
            {
                Children = {
					_iiEmpList
				}
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _iiEmpList.ItemsSource = new[] { new LeaveRequest { FullName = "Gagandeep Singh", ToDate = System.DateTime.Now.AddDays(3), FromDate = DateTime.Now, Notes = "Request for Urgent peace of work", IsApproved=true }, };//ViewModel.EmployeeList;
        }
    }

    #region Custom View cell 
    /// <summary>
    /// This class is a ViewCell that will be displayed for each Employee Cell.
    /// </summary>
    class NotificationViewCell : ViewCell
    {
        public NotificationViewCell()
        {
            var EmpImage = new CircleImage()
             {
                 HorizontalOptions = LayoutOptions.Start,
                 BorderThickness = 5,
                 Source = "NainaSharma.png",
                 BorderColor = Color.White,
                 Aspect = Aspect.Fill,
             };
           // EmpImage.SetBinding(Image.SourceProperty, new Binding("ImageUri"));
            var nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                FontSize=15,
                TextColor=Xamarin.Forms.Color.White
            };

            nameLabel.SetBinding(Label.TextProperty, "FullName");
            var daysLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Xamarin.Forms.Color.White
            };

            daysLabel.SetBinding(Label.TextProperty, "ApprovedDays");
            var subjectLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Xamarin.Forms.Color.White
            };

            subjectLabel.SetBinding(Label.TextProperty, "Notes");
            EmpImage.WidthRequest = EmpImage.HeightRequest = 70;

            var toDate = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Xamarin.Forms.Color.White
            };
            toDate.SetBinding(Label.TextProperty, "LeaveDate");

            var fromDate = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Xamarin.Forms.Color.White
            };
            fromDate.SetBinding(Label.TextProperty, new Binding("FromDate") { StringFormat = "{0:dd-MMM-yyyy}" });

            Button btnApproved = new Button { 
                Text="Approved",
                BackgroundColor=Color.Green,
                FontSize = 10,
            };

            Button btnRejected = new Button
            {
                Text = "Reject",
                BackgroundColor = Color.Red,
                FontSize=10,
            };
            View flagView = new StackLayout {  };

            //TODO: Have to add pending color
            flagView.SetBinding(View.BackgroundColorProperty, new Binding("IsApproved", BindingMode.Default, LeaveFlagColorConverter.OneWay<bool, Color>((status) => status ? InsideInning.Helper.Color.LightGreen.ToFormsColor() : InsideInning.Helper.Color.LightRed.ToFormsColor())));

            #region Adding Context Actions To List view Cell

            var actionApproved = new MenuItem { Text = "Approved" };
            actionApproved.Clicked += async (sender, e) =>
            {
                
                flagView.BackgroundColor = Color.Green;
            };
            var actionReject = new MenuItem { Text = "Reject",IsDestructive=true };
            actionReject.Clicked += async (sender, e) =>
            {
               
                flagView.BackgroundColor = Color.Red;
            };
            ContextActions.Add(actionApproved);
            ContextActions.Add(actionReject);

            #endregion
            
            RelativeLayout MainView = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.Start,
                Padding = new Thickness(20, 10, 5, 5),
            };

            MainView.Children.Add(EmpImage, Constraint.Constant(5), Constraint.Constant(10),
                 Constraint.Constant(60),
                 Constraint.Constant(60));
            MainView.Children.Add(subjectLabel, Constraint.Constant(80), Constraint.Constant(50), Constraint.RelativeToParent(parent => { return parent.Width; }), Constraint.Constant(40));
            MainView.Children.Add(nameLabel, Constraint.Constant(80), Constraint.Constant(5), Constraint.RelativeToParent(parent => { return parent.Width; }), Constraint.Constant(20));

            MainView.Children.Add(toDate, Constraint.Constant(80), Constraint.Constant(27), Constraint.RelativeToParent(parent => { return parent.Width- daysLabel.Width; }), Constraint.Constant(40));
            //MainView.Children.Add(fromDate, Constraint.Constant(180), Constraint.Constant(27), Constraint.Constant(100), Constraint.Constant(40));
            MainView.Children.Add(daysLabel, Constraint.Constant(290), Constraint.Constant(27), Constraint.Constant(50), Constraint.Constant(20));
            //MainView.Children.Add(btnApproved, Constraint.Constant(290), Constraint.Constant(5), Constraint.Constant(60), Constraint.Constant(30));
            //MainView.Children.Add(btnRejected, Constraint.Constant(290), Constraint.Constant(40), Constraint.Constant(60), Constraint.Constant(30));
            MainView.Children.Add(flagView, Constraint.RelativeToParent(parent => { return parent.Width-7; }), Constraint.Constant(2), Constraint.Constant(7), Constraint.Constant(76));

            View = MainView;
        }
        
    }
    #endregion
}
