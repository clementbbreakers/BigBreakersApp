using Xamarin.Forms;

namespace BigBreakers
{
	public partial class SignupPage : ContentPage
	{
		public SignupPage()
		{
			InitializeComponent();
			this.BindingContext = App.Locator.Signup;
			signupButton.TextColor = Color.FromHex("50E3C2");
			signupButton.BorderColor = Color.FromHex("50E3C2");
		}
	}
}
