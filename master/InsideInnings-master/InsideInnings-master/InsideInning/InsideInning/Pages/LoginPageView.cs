using InsideInning.Helper;
using InsideInning.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Color = InsideInning.Helper.Color;


namespace InsideInning.Pages
{
	public class LoginPageView : BaseViewPage
	{

		public LoginViewModel ViewModel
		{
			get
			{
				return BindingContext as LoginViewModel;
			}
		}

		public LoginPageView()
		{
			BindingContext = new LoginViewModel(this.Navigation);
			BackgroundImage = "back.png";
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {      
                    CreateStackfor(),
                }
            };
		}

		private StackLayout CreateStackfor()
		{
			var layout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Padding = new Thickness(30, 30, 30, 30),
				Spacing = 10,
				BackgroundColor = Color.LightRed.ToFormsColor(),
				Children =
				{
					CreateEntryFor("Username", Color.iiTextColor, "5"),
					CreateEntryFor("Password", Color.iiTextColor, "6", true),
					CreateButtonFor("Login"),                             
				}
			};

			return layout;
		}

		public static View CreateEntryFor(string propertyName, Color color, string id = "", bool IsPassword = false)
		{
			iiTextBox iiEditTextBox = new iiTextBox
			{
                TextColor = Xamarin.Forms.Color.White,
				IsPassword = IsPassword,
				Placeholder = propertyName,
				BackgroundColor = Xamarin.Forms.Color.Transparent, //Color.iiEditTextColor.ToFormsColor(),
				ClassId = id,
				TranslationY = 2,
				WidthRequest = 200,
			};
            iiEditTextBox.SetBinding(Entry.TextProperty,propertyName);
			return iiEditTextBox;
		}

		public Button CreateButtonFor(string propertyName)
		{
			Button iiButton = new Button
			{
				Text = propertyName,
				TextColor = Color.LightRed.ToFormsColor(),
				BackgroundColor = Color.LightGreen.ToFormsColor(),
				BorderWidth = 1,
                //BorderColor = Color.LightGreen.ToFormsColor(),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 40,
				FontSize = 16,
				Command = ViewModel.LoginCommand,
			};

			return iiButton;
		}

        //void iiButton_Clicked(object sender, EventArgs e)
        //{
        //    this.Navigation.PushAsync(new DashboardViewPage(this));
        //}


        //rzee
        #region Login View

        public RelativeLayout CreateRealtiveLayoutFor()
        {
            RelativeLayout MainView = new RelativeLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Xamarin.Forms.Color.Transparent,
                Padding = new Thickness(1, 1, 1, 1),
                HeightRequest = WidthRequest = 250,

            };
            var backView = new iiImage { VerticalOptions = LayoutOptions.Center, Source="loginBack.png" , BackgroundColor=Xamarin.Forms.Color.Transparent};

            MainView.Children.Add(backView, Constraint.Constant(0), Constraint.Constant(0),
                Constraint.Constant(250),
                 Constraint.Constant(250));

            //MainView.Children.Add(CreateStackfor(), Constraint.Constant(0), Constraint.Constant(0),
            //   Constraint.Constant(250),
            //    Constraint.Constant(250));

            //MainView.Children.Add(CreateStackfor(), Constraint.Constant(0),
            //Constraint.RelativeToView(backView, (parent, sibling) => { return sibling.Height; }), Constraint.Constant(100), Constraint.Constant(100));

            return MainView;
        }
        
        #endregion
    }
}

