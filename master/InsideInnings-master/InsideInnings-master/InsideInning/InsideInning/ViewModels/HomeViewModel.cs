using InsideInning.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace InsideInning.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<HomeMenuItem> MenuItems { get; set; }
        public HomeViewModel()
        {
            Title = "Hello";
            MenuItems = new ObservableCollection<HomeMenuItem>();

            MenuItems.Add(new HomeMenuItem
            {
                ID = 0,
                Title = "Dashboard",
                MenuType = MenuType.Dashboard
            }); MenuItems.Add(new HomeMenuItem
            {
                ID = 1,
                Title = "Create an Account",
                MenuType = MenuType.EmployeeAccount
            });

            MenuItems.Add(new HomeMenuItem
            {
                ID = 2,
                Title = "Logout",
                MenuType = MenuType.Logout
            });

        }
        public LoginViewModel LogViewModel { get; set; }

    }
}
