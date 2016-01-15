using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

using ImageCircle.Forms.Plugin.Abstractions;
using InsideInning.Models;
using System.Threading;
namespace InsideInning.Pages
{
    public class EmployeeListViewPage : BaseViewPage
    {
        private EmployeeViewModel ViewModel
        {
            get { return BindingContext as EmployeeViewModel; }
        }
        ListView _iiEmpList = null;
        public EmployeeListViewPage()
        {

            BindingContext = new EmployeeViewModel();
            var activity = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Color = Color.White,
                //IsEnabled = true
            };
            activity.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
            activity.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");

            //Command
            ViewModel.LoadAllEmployees.Execute(null);

            _iiEmpList = new iiListView()
            {
                ItemTemplate = new DataTemplate(typeof(EmployeeNameCell)),
                ClassId="1",    
                RowHeight=70
            };
            Content = new StackLayout
            {
                Children = {
                    activity,
					_iiEmpList
				}
            };
            _iiEmpList.ItemTapped += _iiEmpList_ItemTapped;
        }

        void _iiEmpList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var _EmpID = ((Employee)e.Item).EmployeeID;
            this.Navigation.PushAsync(new EmpDetailsViewPage((Employee)e.Item, ViewModel));
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _iiEmpList.ItemsSource = ViewModel.EmployeeList;
            //new[] { new Employee() {  EmployeeID=1, FirstName = "Naina", LastName = "Sharma", EmailAddress = "naina.sharma@gmail.com", Password = "naina" }, 
            //                                 new Employee() {   EmployeeID=2, FirstName = "Mohd", LastName = "Riyaz", EmailAddress = "mRiyaz@gmail.com", Password = "Riyaz" },
            //                                 new Employee() {   EmployeeID=3,FirstName = "gagan",LastName="deep",EmailAddress="gagan.deep@gmail.com", Password="gagan" }};
        }
    }

    #region Custom View cell
    /// <summary>
    /// This class is a ViewCell that will be displayed for each Employee Cell.
    /// </summary>
    class EmployeeNameCell : ViewCell
    {
        public EmployeeNameCell()
        {
            
            var EmpImage = new CircleImage()
            {
                HorizontalOptions = LayoutOptions.Start,
                //BorderThickness=5,
                //Source = "Pics/ 5b571de8-5e8c-4991-9bcb-113348e66d69.jpeg",
                //BorderColor=Color.White,
                Aspect = Aspect.Fill,
            };
            EmpImage.SetBinding(Image.SourceProperty, new Binding("EmpProfileImage"));
            EmpImage.WidthRequest = EmpImage.HeightRequest = 70;

            var nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Color.White
            };
            nameLabel.FontSize = 15;
            nameLabel.SetBinding(Label.TextProperty, "FullName");

            var Designation = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Color.White
            };
            Designation.FontSize = 15;
            Designation.SetBinding(Label.TextProperty, "EmailAddress");

            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                Padding = new Thickness(0, 2.5, 0, 1.5),
                HeightRequest = 10,
                Spacing = 0,
                Children = {
                    EmpImage,
                    //new Image{Source="index.jpg",HeightRequest=50,WidthRequest=50},
					new StackLayout {
                        Spacing=0,
						Orientation = StackOrientation.Vertical,
                        VerticalOptions=LayoutOptions.Start,
                        Padding=0,
						Children = { nameLabel, Designation }
					},
					
				}
            };
        }
    }
    #endregion
    
}
