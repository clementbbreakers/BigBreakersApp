using System;
using Xamarin.Forms;

namespace BigBreakers
{
	public class PlayerTabbedPage:TabbedPage
	{
		public PlayerTabbedPage()
		{
			var page = new NavigationPage(new MapPage());
			page.Title = "Carte";
			page.Icon = "PinTabBar.png";

			var informationPage = new NavigationPage(new PlayerAllInformationsTable());
			informationPage.Title = "Profil";
			informationPage.Icon = "profiltab.png";
			Children.Add(informationPage);
			Children.Add(page);
			CurrentPage = Children[1];
		}
	}
}
