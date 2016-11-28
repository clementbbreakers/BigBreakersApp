using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Parse;

namespace BigBreakers
{
	public class PhoneValidationViewModel:ViewModelBase
	{
		public RelayCommand confirmCommand { get; private set;}
		public string code { get; set;}

		public PhoneValidationViewModel()
		{
			confirmCommand = new RelayCommand(async () => await checkValidationCode());
		}

		private async Task checkValidationCode()
		{
			var user = ParseUser.CurrentUser as UserModel;
			await user.FetchAsync();
			if (user.phoneVerificationCode == code)
			{
				await user.FetchIfNeededAsync();
				user.publicData.phoneVerified = true;
				await user.publicData.SaveAsync();
				await App.Current.MainPage.Navigation.PushAsync(new UserTypePage());
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("ko");
			}
		}
	}
}
