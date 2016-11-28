using Xamarin.Forms;
using Parse;
using BigBreakers.ViewModel;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Newtonsoft.Json.Linq;

namespace BigBreakers
{
	public partial class App : Application
	{
		private static ViewModelLocator _locator;
		private static NavigationPage _NavPage;
		public static ViewModelLocator Locator
		{
			get
			{
				return _locator ?? (_locator = new ViewModelLocator());
			}
		}
		public App()
		{
			InitializeComponent();
			ParseObject.RegisterSubclass<UserModel>();
			ParseObject.RegisterSubclass<UserPublicData>();
			ParseObject.RegisterSubclass<BrandModel>();
			ParseObject.RegisterSubclass<RacketModel>();
			ParseClient.Initialize(new ParseClient.Configuration
			{
				ApplicationId = "myAppId",
				Server = "http://bigbreakers.herokuapp.com/parse/" // trailing slash is important
			});
			_NavPage = new NavigationPage(new PrivateProfileTablePage())
			{
				BarBackgroundColor = Color.FromHex("50E3C2"),
				BarTextColor = Color.White
			};
			MainPage = new PlayerTabbedPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

		public static async void SuccessFacebookLogin(string sessionToken,JObject obj)
		{
			var data = new UserPublicData()
			{
				firstName = obj["first_name"].ToString(),
				lastName = obj["last_name"].ToString(),
				gender = obj["gender"].ToString()
			};
			await data.SaveAsync().ConfigureAwait(false);
			await ParseUser.BecomeAsync(sessionToken);
			(ParseUser.CurrentUser as UserModel).publicData = data;
			await ParseUser.CurrentUser.SaveAsync();
			System.Diagnostics.Debug.WriteLine(ParseUser.CurrentUser.Username);
		}

		public static Action SuccessfulLoginAction
		{
			get
			{
				return new Action(() =>
				{
					App.Current.MainPage.Navigation.PushAsync(new PhoneNumberCodePage());
				});
			}
		}
	}
}

