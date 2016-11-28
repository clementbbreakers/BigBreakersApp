using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms.GoogleMaps;

namespace BigBreakers
{
	public class LocationService
	{
		private readonly IGeolocator _locator;
		private readonly Geocoder geoCoder = new Xamarin.Forms.GoogleMaps.Geocoder();
		private readonly GooglePlaceService _service;
		private int _timeout = 100000;

		public LocationService(GooglePlaceService service)
		{
			_service = service;
			_locator = CrossGeolocator.Current;
			_locator.DesiredAccuracy = 100;
		}

		public async Task<Plugin.Geolocator.Abstractions.Position> getCurrentPosition()
		{
			return await _locator.GetPositionAsync(_timeout);
		}

		public async Task<List<AutoCompleteModel>> AutoCompleteAdress(string address)
		{
			var content = await _service.getPlacesAutocomplete(address).ConfigureAwait(false);;
			List<AutoCompleteModel> modelArray = new List<AutoCompleteModel>();
			JArray array = (JArray)content["predictions"];
			foreach (JToken token in array)
			{
				var model = JsonConvert.DeserializeObject<AutoCompleteModel>(token.ToString());
				modelArray.Add(model);
			}
			return modelArray;
		}

		public async Task<string> getAddressForPosition(Xamarin.Forms.GoogleMaps.Position position)
		{
			var address = await geoCoder.GetAddressesForPositionAsync(position).ConfigureAwait(false);
			return address.First().Split('\n')[0];
		}
		public async Task<Plugin.Geolocator.Abstractions.Position> getDetailPlace(string id)
		{
			var detail = await _service.getDetailPlaceInfo(id).ConfigureAwait(false);
			var location = detail["result"]["geometry"]["location"];
			var latitude = double.Parse(location["lat"].ToString());
			var longitude = double.Parse(location["lng"].ToString());
			var position = new Plugin.Geolocator.Abstractions.Position();
			position.Latitude = latitude;
			position.Longitude = longitude;
			return position;
		}
	}
}
