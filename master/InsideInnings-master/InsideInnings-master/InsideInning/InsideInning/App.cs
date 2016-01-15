using InsideInning.Data;
using InsideInning.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace InsideInning
{
	public class App : Application
	{
		private static Page homeView;

		public static Page RootPage
		{
			get { return homeView ?? (homeView = new LoginPageView()); }
		}

		public App()
		{
			//var resolverContainer = new SimpleContainer();
			//resolverContainer.Register<IMediaPicker>(new MediaPicker());

			MainPage = homeView ?? (homeView = new LoginPageView());
		}

		#region Database Instance

		private static InsideInningData _database;

		public static InsideInningData DataBase
		{
			get
			{
				if (_database == null)
					_database = new InsideInningData();
				return _database;
			}
		}

		#endregion
	}
}
