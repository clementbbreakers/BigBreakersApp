using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BigBreakers
{
	public partial class PrivateProfileCordeurPage : ContentPage
	{
		public PrivateProfileCordeurPage()
		{
			InitializeComponent();
			this.BindingContext = App.Locator.ProfilePlayer;
		}
	}
}
