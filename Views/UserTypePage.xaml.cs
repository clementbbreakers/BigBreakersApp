using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Parse;

namespace BigBreakers
{
	public partial class UserTypePage : ContentPage
	{
		UserModel user = ParseUser.CurrentUser as UserModel;
		public UserTypePage()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();
			playerButton.Clicked += (sender, e) =>
			{
				playerButton.Image = "PlayerFillButton";
				cordeurButton.Image = "CordeurEmptyButton";
				setType("PLAYER");
			};
			cordeurButton.Clicked += (sender, e) =>
			{
				playerButton.Image = "PlayerEmptyButton";
				cordeurButton.Image = "CordeurFillButton";
				setType("CORDEUR");
			};
			confirmButton.Clicked += async (sender, e) =>
			{
				await user.publicData.SaveAsync();
				if (user.publicData.type == "PLAYER")
				{
					await Navigation.PushAsync(new PrivateProfileTablePage());
				}
				else
				{
					await Navigation.PushAsync(new PrivateProfileCordeurPage());
				}
			};
		}
		private void setType(string type)
		{
			confirmButton.IsEnabled = true;
			confirmButton.TextColor = Color.Red;
			confirmButton.BorderColor = Color.Red;
			user.publicData.type = type;
		}
	}
}
