using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
namespace BigBreakers.ViewModel
{
	public class LoginViewModel : ViewModelBase
	{
		public RelayCommand signupCommand { get; private set;}
		public LoginViewModel()
		{
			signupCommand = new RelayCommand(() => signup());
		}

		private async void signup()
		{
			
		}
	}
}
