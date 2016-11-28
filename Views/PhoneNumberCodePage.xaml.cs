using System;
using System.Collections.Generic;
using Parse;
using Xamarin.Forms;

namespace BigBreakers
{
	public partial class PhoneNumberCodePage : ContentPage
	{
		public PhoneNumberCodePage()
		{
			InitializeComponent();
			this.BindingContext = App.Locator.phoneValidation;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			entryCode.Focus();
		}
	}
}
