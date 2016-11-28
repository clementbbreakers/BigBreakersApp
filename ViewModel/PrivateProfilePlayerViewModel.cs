using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Parse;
using Xamarin.Forms;

namespace BigBreakers
{
	public class PrivateProfilePlayerViewModel
	{
		public UserPublicData publicData { get; set;}
		public UserModel user { get; set;}
		public RelayCommand ValidateCommand { get; private set; }
		public bool fromTabBar;
		public PrivateProfilePlayerViewModel()
		{
			ValidateCommand = new RelayCommand(async () => await saveUserInformations());
			user = ParseUser.CurrentUser as UserModel;
			publicData = (ParseUser.CurrentUser as UserModel).publicData;
			new Action(async () =>
			{
				await publicData.FetchAsync();
				//MessagingCenter.Send(publicData.profilePicture, "setProfilePicture");
			}).Invoke();
		}

		private async Task saveUserInformations()
		{
			//await user.SaveAsync();
			if (publicData.gender == "Homme")
			{
				publicData.gender = "male";
				System.Diagnostics.Debug.WriteLine("coucou");
			}
			else if (publicData.gender == "Femme")
			{
				publicData.gender = "female";
			}
			await publicData.SaveAsync();
			var sendData = new Dictionary<string, object>();
			sendData["type"] = publicData.type;
			if (fromTabBar)
				await (App.Current.MainPage as PlayerTabbedPage).Children[0].Navigation.PopAsync();
			else
				await App.Current.MainPage.Navigation.PushAsync(new RacketChoicePage());
		}

		public void setProfilePicture(ParseFile file)
		{
			publicData.profilePicture = file;
		}
	}
}
