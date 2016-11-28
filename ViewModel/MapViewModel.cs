using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using Parse;

namespace BigBreakers
{
	public class MapViewModel : ViewModelBase
	{
		private LocationService _service;
		private bool canShowAutoCompleteList = false;
		private ObservableCollection<AutoCompleteModel> _addresses = new ObservableCollection<AutoCompleteModel>();
		private Command<string> autocompleteSearchCommand;
		private UserModel currentUser = ParseUser.CurrentUser as UserModel;
		public Command<string> AutocompleteSearchCommand
		{
			get { return autocompleteSearchCommand ?? (autocompleteSearchCommand = new Command<string>(async (param) => await ExecuteAutocompleteSearchCommand(param))); }
		}

		async Task ExecuteAutocompleteSearchCommand(string param)
		{
			if (canShowAutoCompleteList == true)
			{
				var array = await _service.AutoCompleteAdress(param).ConfigureAwait(false);
				Addresses = new ObservableCollection<AutoCompleteModel>(array);
			}
			else {
				canShowAutoCompleteList = true;
			}
		}
		public ObservableCollection<AutoCompleteModel> Addresses
		{
			get { return _addresses; }
			set { _addresses = value; RaisePropertyChanged(() => Addresses); }
		}

		private Command selectedSearchitem;

		private async Task ExecuteSelectedSearchitemCommand(object itm)
		{
			var model = itm as AutoCompleteModel;
			var position = await _service.getDetailPlace(model.place_id);
			MessagingCenter.Send(position, "AutoCompleteSelect");
			return;
		}

		public Command SelectedSearchitem
		{
			get { return selectedSearchitem ?? (selectedSearchitem = new Command(async (itm) => await ExecuteSelectedSearchitemCommand(itm))); }
		}

		private string searchText;

		public string SearchText
		{
			get
			{
				return searchText;
			}
			set
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					searchText = value;
					RaisePropertyChanged(() => SearchText);
				}
			}
		}

		public RelayCommand OrderCommand { get; private set;}
		public MapViewModel(LocationService service)
		{
			_service = service;
			OrderCommand = new RelayCommand(async () => await doOrder());
		}

		private async Task doOrder()
		{
			await currentUser.publicData.FetchAsync();
			var rackets = currentUser.publicData.Get<IList<RacketModel>>("rackets");
			if (rackets.Count > 0) //Affiche liste racket
			{
				var tab = App.Current.MainPage as PlayerTabbedPage;
				await tab.Children[1].Navigation.PushAsync(new RacketOrderChoicePage());
			}
		}

		public async Task<Position> getCurrentLocation()
		{
			var position =  await _service.getCurrentPosition();
			var address = await getAddressForLocation(position);
			SearchText = address;
			return position;
		}
		public async Task<string> getAddressForLocation(Position position)
		{
			var GPosition = new Xamarin.Forms.GoogleMaps.Position(position.Latitude,position.Longitude);
			return await _service.getAddressForPosition(GPosition);
		}
	}
}
