using InsideInning.Helper;
using InsideInning.Models;
using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;

namespace InsideInning.Pages
{
    public class HomeViewPage : MasterDetailPage
    {
        private HomeViewModel ViewModel
            {
                get { return BindingContext as HomeViewModel; } //Type cast BindingContex as HomeViewModel to access binded properties
            }

        private Dictionary<MenuType, iiNavigationPage> pages;
        HomeMasterPage _master;
        //LoginViewModel loginViewModel;
        public HomeViewPage(LoginViewModel loginViewModel)
        {
            pages = new Dictionary<MenuType, iiNavigationPage>();
            BindingContext = new HomeViewModel();
            ViewModel.LogViewModel = loginViewModel;
            Master = _master = new HomeMasterPage(ViewModel);
            var homeNav = new iiNavigationPage(_master.PageSelection)
            {
                // BackgroundColor = Helper.Color.Pink.ToFormsColor(),
                // BarTextColor = Helper.Color.White.ToFormsColor(),
                //BarBackgroundColor= Helper.Color.iiGreen.ToFormsColor()
            };
            Detail = homeNav;
            pages.Add(MenuType.Dashboard, homeNav);
            _master.PageSelectionChanged = async (menuType) =>
            {

                if (Detail != null && Device.OS == TargetPlatform.WinPhone)
                {
                    await Detail.Navigation.PopToRootAsync();
                }

                iiNavigationPage newPage;
                if (pages.ContainsKey(menuType))
                {
                    newPage = pages[menuType];
                }
                else
                {
                    newPage = new iiNavigationPage(_master.PageSelection)
                    {
                        // BarBackgroundColor = Helper.Color.iiPurple.ToFormsColor(),
                        //BarTextColor = Xamarin.Forms.Color.White
                        //GO inside iiNavigaton Constructor
                    };
                    pages.Add(menuType, newPage);
                }
                Detail = newPage;
                Detail.Title = _master.PageSelection.Title;
                IsPresented = false;
            };
            this.Icon = "slideout.png";
        }

        public class HomeMasterPage : BaseViewPage
        {
            public Action<MenuType> PageSelectionChanged;
            private Page _pageSelection;
            private MenuType menuType = MenuType.Dashboard;

            public Page PageSelection
            {
                get { return _pageSelection; }
                set
                {
                    _pageSelection = value;
                    if (PageSelectionChanged != null)
                        PageSelectionChanged(menuType);
                }
            }

            private AddEmployeeViewPage EmployeeAccount;
            private DashboardViewPage DashBoard;
            private LoginPageView Logout;
            public HomeMasterPage(HomeViewModel viewModel)
            {
                BackgroundImage = "back.png";
                this.Icon = "slideout.png";
                Title = "test";
                var layout = new StackLayout { Spacing = 0 };

                var listView = new iiListView
                {
                    ClassId="1",
                };// Listview created for menu items
                var cell = new DataTemplate(typeof(ListImageCell));
                cell.SetBinding(TextCell.TextProperty, HomeViewModel.TitlePropertyName);
                listView.ItemTemplate = cell;


                //BackgroundImage = "iiListBack.";
                listView.ItemsSource = viewModel.MenuItems;
                listView.BackgroundColor= Xamarin.Forms.Color.Transparent;
                if (DashBoard == null)   //Making First view page selection
                    DashBoard = new DashboardViewPage( );
                PageSelection = DashBoard;

                listView.ItemSelected += (sender, args) =>
                {
                    
                    var menuItem = listView.SelectedItem as HomeMenuItem;
                    menuType = menuItem.MenuType;
                    switch (menuItem.MenuType)
                    {
                        case MenuType.Dashboard:
                            if (DashBoard == null)
                                DashBoard = new DashboardViewPage();

                            PageSelection = DashBoard;
                            break;
                        case MenuType.EmployeeAccount:
                            if (EmployeeAccount == null)
                                EmployeeAccount = new AddEmployeeViewPage();
                            PageSelection = EmployeeAccount;
                            break;

                        case MenuType.Logout:
                            if (Logout == null)
                                Logout = new LoginPageView();

                            PageSelection = Logout;
                            break;
                    }
                };
                layout.Children.Add(listView);
                Content = layout;
            }
        }
    }
}
