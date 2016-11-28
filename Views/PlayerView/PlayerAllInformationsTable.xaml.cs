using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BigBreakers
{
	public partial class PlayerAllInformationsTable : ContentPage
	{
		public PlayerAllInformationsTable()
		{
			InitializeComponent();
			personalInfos.Tapped += async (sender, e) =>
			{
				await Navigation.PushAsync(new PrivateProfileTablePage(true));
			};
		}
	}
}
