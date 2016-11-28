using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Parse;

namespace BigBreakers
{
	public partial class RacketChoicePage : ContentPage
	{
		private RacketChoiceViewModel _viewModel;
		private IEnumerable<BrandModel> _brands;
		private IEnumerable<RacketModel> _currentRackets;
		public string Brand { get; set;}

		public RacketChoicePage()
		{
			InitializeComponent();
			_viewModel = App.Locator.RacketChoice;
			this.BindingContext = _viewModel;

			skipButton.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new MapPage());
			};
			BrandPicker.SelectedIndexChanged += async (object sender, EventArgs e) =>
			{
				var brandString = BrandPicker.Items[BrandPicker.SelectedIndex];
				var model = _brands.First((arg) => arg.name == brandString);
				_currentRackets = await _viewModel.getRacketsForBrand(model);
				ModelPicker.Items.Clear();
				ModelPicker.Title = "Slectionner votre modèle de raquette";
				foreach (RacketModel racket in _currentRackets)
				{
					ModelPicker.Items.Add(racket.model);
				}
			};
			ConfirmButton.Clicked += async (object sender, EventArgs e) =>
			{
				var racketString = ModelPicker.Items[ModelPicker.SelectedIndex];
				var racket = _currentRackets.First((arg) => arg.model == racketString);
				var user = ParseUser.CurrentUser as UserModel;
				if (user.publicData.rackets == null)
				{
					user.publicData.rackets = new List<RacketModel>();
				}
				user.publicData.rackets.Add(racket);
				await user.publicData.SaveAsync();
			};
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var brands = await _viewModel.getBrands();
			_brands = brands;
			foreach (BrandModel brand in brands)
			{
				BrandPicker.Items.Add(brand.name);
			}
		}
	}
}
