using Xamarin.Forms;
using Parse;
namespace BigBreakers
{
	public partial class BigBreakersPage : ContentPage
	{
		public BigBreakersPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();
			this.BindingContext = App.Locator.Login;
			email.Clicked +=  async (sender, e) =>
			{
				await Navigation.PushAsync(new SignupPage());
			};

			facebookButton.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new FacebookLoginPage());
			};
		}
	}
}

