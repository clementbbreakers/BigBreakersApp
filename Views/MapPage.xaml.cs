using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Plugin.Geolocator.Abstractions;
using System.Collections.ObjectModel;

namespace BigBreakers
{
	public partial class MapPage : ContentPage
	{
		private readonly MapViewModel viewModel;
		public MapPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			viewModel = App.Locator.Map;
		    this.BindingContext = viewModel;
			InitializeComponent();
			MessagingCenter.Subscribe<Plugin.Geolocator.Abstractions.Position>(this, "AutoCompleteSelect", (pos) =>
			{
				System.Diagnostics.Debug.WriteLine("Need to move map");
				moveMapToPosition(pos);
			});
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			Test.Focus();
			var position = await viewModel.getCurrentLocation();
			moveMapToPosition(position);
		}
		private void moveMapToPosition(Plugin.Geolocator.Abstractions.Position position)
		{
			mapView.MoveToRegion(
					MapSpan.FromCenterAndRadius(
					new Xamarin.Forms.GoogleMaps.Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));
			System.Diagnostics.Debug.WriteLine("Map Moved");
		}
	}
}
