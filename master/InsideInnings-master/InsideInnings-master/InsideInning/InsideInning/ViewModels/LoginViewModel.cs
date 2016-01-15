using InsideInning.Helpers;
using InsideInning.Models;
using InsideInning.Pages;
using InsideInning.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InsideInning.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		INavigation iiNavigation;



		public LoginViewModel(INavigation navigation)
		{
			this.iiNavigation = navigation;
			EmpViewModel = new EmployeeViewModel();

		}

		#region Employee

		private Employee _employee;

		public Employee EployeeInfo
		{
			get { return _employee; }
			set { _employee = value; }
		}


		#endregion

        #region CheckLogin Properties

        public CheckLogin CheckLogin
        {
            get { return  new CheckLogin { UserName = this.Username, Password = this.Password }; }
        }

        private string _userName="m.riyaz@invertedi.com";

        public string Username
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged("Username"); }
        }

        private string _password="IAm7MOM";

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }



        #endregion  

        #region Login Command

		private Command logoutCommand;

		public Command LogoutCommand
		{
			get
			{
				return logoutCommand ?? (logoutCommand = new Command(async () => await ExecuteLogoutCommand()));
			}
		}


        private Command loginCommand;

        public Command LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommand()));
            }
        }

        private async Task ExecuteLoginCommand()
        {
            try
            {
                if (!IsNetworkConnected) //Have to remove !
                {
                    var data = await ServiceHandler.PostDataAsync<Employee, CheckLogin>(CheckLogin, Constants.CheckLogin);//.ContinueWith(t =>
                    NavigationToPage(data);
                }
                else
                {
                    //TODO : login locally forn database
                    NavigationToPage(null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Exception Occurred : {0}", ex.Message);
            }
        }

		private void NavigationToPage(Employee t)
		{
			if (t != null && t.IsAdmin)
			{
				iiNavigation.PushModalAsync(new HomeViewPage(this), true);
			}
			else
			{
				//TODO : We'll remove it on fly code
				iiNavigation.PushModalAsync(new HomeViewPage(this), true);

                //var navPage = new iiNavigationPage(new DashboardViewPage(this));
                //iiNavigation.PushModalAsync(navPage, true);

			}
		}

		private async Task ExecuteLogoutCommand()
		{
			try
			{
				await iiNavigation.PushModalAsync(new LoginPageView(), true);
			}
			catch (Exception ex)
			{
				Console.WriteLine("An Exception Occurred : {0}", ex.Message);
			}
		}

		#endregion


		//TODO : Have to remove
		public EmployeeViewModel EmpViewModel { get; set; }
	}
}
