using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;

namespace InsideInning.Pages
{
    public class BalanceLeaveViewPage : BaseViewPage
    {
        private EmployeeViewModel ViewModel
        {
            get { return BindingContext as EmployeeViewModel; }
        }

        ListView listView = null;
        public BalanceLeaveViewPage()
        {
            BindingContext = new EmployeeViewModel();
            var activity = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Color = Color.White.ToFormsColor(),
                //IsEnabled = true
            };
            activity.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");
            activity.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            ViewModel.LoadAllEmployees.Execute(null);
            listView = new iiListView()
            {
                ItemTemplate = new DataTemplate(typeof(NameCell))
            };

            BackgroundImage = "back";
            Content = new StackLayout
            {
                // HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20, 70, 20, 20),
                Spacing=20,
                Children = 
                {
                    activity,  
                    listView,
                    GenCalGrid(),
                }
            };
            listView.ItemTapped += listView_ItemTapped;
        }
        void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = ViewModel.EmployeeList;
         }
        private Grid GenCalGrid()
        {
            var grid = new Grid()
            {
                ColumnSpacing=2,
                RowSpacing=2,
            };

            grid.Children.Add(CreateLabelFor("Leave Type",LayoutOptions.Start,"2"), 0, 0);
            grid.Children.Add(CreateLabelFor("Total", Color.Purple, LayoutOptions.Start,"",true), 1, 0);
            grid.Children.Add(CreateLabelFor("Used", Color.Purple, LayoutOptions.Start,"",true), 2, 0);
            grid.Children.Add(CreateLabelFor("Pending", LayoutOptions.Start, "3"), 3, 0);

            grid.Children.Add(CreateLabelFor("Casual Leave", Color.Purple, LayoutOptions.Start,"",true), 0, 1);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 1, 1);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 2, 1);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 3, 1);

            grid.Children.Add(CreateLabelFor("Medical Leave", Color.Purple, LayoutOptions.Start,"",true), 0, 2);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 1, 2);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 2, 2);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 3, 2);

            grid.Children.Add(CreateLabelFor("Paid Leave", Color.Purple, LayoutOptions.Start,"",true), 0, 3);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 1, 3);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 2, 3);
            grid.Children.Add(CreateLabelFor("0", Color.White, LayoutOptions.Start), 3, 3);

            return grid;
        }
        #region Custom Label
        public View CreateLabelFor(string propertyName,Color color, LayoutOptions layout, string id = "",bool isHeader=false)
        {
            iiLabel iiLabel = new iiLabel
            {

                TextColor = isHeader?  Color.White.ToFormsColor():Color.DarkBlue.ToFormsColor(),
                Text = propertyName,
                HorizontalOptions = layout,
                HeightRequest = 25,
                WidthRequest=130,
                FontSize = 10,
                ClassId = id,
                XAlign=TextAlignment.Center,
                YAlign = TextAlignment.Center,
                BackgroundColor=color.ToFormsColor(),
            };
            return iiLabel;
        }
        public View CreateLabelFor(string propertyName, LayoutOptions layout, string id = "")
        {
            iiLabel iiLabel = new iiLabel
            {
                TextColor = Color.White.ToFormsColor(),
                Text = propertyName,
                HorizontalOptions = layout,
                HeightRequest = 25,
                WidthRequest = 120,
                FontSize = 10,
                ClassId = id,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };
            return iiLabel;
        }
        #endregion

    }
    #region Custom View cell
    /// <summary>
    /// This class is a ViewCell that will be displayed for each Employee Cell.
    /// </summary>
    class NameCell : ViewCell
    {
        public NameCell()
        {
            var nameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Start,

            };
            nameLabel.FontSize = 15;
            nameLabel.SetBinding(Label.TextProperty, "FirstName");

            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                Padding = new Thickness(0, 1.5, 0, 1.5),
                HeightRequest = 10,
                Spacing = 0,
                Children = {
					new StackLayout {
                        Spacing=0,
						Orientation = StackOrientation.Vertical,
                        VerticalOptions=LayoutOptions.Start,
                        Padding=0,
						Children = { nameLabel }
					},
					
				}
            };

        }
    }
    #endregion
}
