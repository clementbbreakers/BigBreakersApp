using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Parse;
using Plugin.Toasts;
using Xamarin.Forms;

namespace BigBreakers.ViewModel
{
	public class SignupViewModel
	{
		public RelayCommand SignupCommand { get; private set; }

		public string firstName { get; set; }
		public string lastName { get; set; }
		public string email { get; set; }
		public string password { get; set; }
		public string confirmPassword { get; set; }
		public string phoneNumber { get; set; }
		private bool canPressButton = true;

		public SignupViewModel()
		{
			SignupCommand = new RelayCommand(async () => await signupUser(), () => canPressButton);
		}

		private async Task signupUser()
		{
			var validator = new SignupValidator();
			var notificator = DependencyService.Get<IToastNotificator>();
			var publicData = new UserPublicData();
			publicData.firstName = firstName;
			publicData.lastName = lastName;
			var user = new UserModel()
			{
				Username = email,
				Password = password,
				Email = email,
				phoneNumber = phoneNumber,
				publicData = publicData
			};
			var result = validator.Validate(user);
			if (!result.IsValid)
			{
				await notificator.Notify(ToastNotificationType.Error, "Erreur", result.Errors[0].ErrorMessage, TimeSpan.FromSeconds(2));
			}
			else 
			{
				user.publicData = publicData;
				var answer = await App.Current.MainPage.DisplayAlert("Confirmation", "Vous reconnaissez avoir lu et accepté les conditions générales ?", "Oui", "Non");
				if (answer == true)
				{
					try
					{
						await publicData.SaveAsync();
						await user.SignUpAsync();
						user.ACL = new ParseACL(user);
						publicData.ACL = new ParseACL(user)
						{
							PublicReadAccess = true,
							PublicWriteAccess = false
						};
						await publicData.SaveAsync();
						await user.SaveAsync();
						await App.Current.MainPage.Navigation.PushAsync(new PhoneNumberCodePage());
					}
					catch (Exception e)
					{
						System.Diagnostics.Debug.WriteLine(e);
					}
				}
			}
		}
	}
}