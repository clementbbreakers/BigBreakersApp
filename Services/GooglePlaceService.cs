using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BigBreakers
{
	public class GooglePlaceService
	{
		private HttpClient _client;
		private string baseUrl = "https://maps.googleapis.com/maps/api/place/autocomplete/json?key=AIzaSyCGgtCS6sS-WQRopBTWBE_7lJ5phxncZog&";
		public GooglePlaceService()
		{
			_client = new HttpClient();
			_client.MaxResponseContentBufferSize = 256000;
		}

		public async Task<JObject> getPlacesAutocomplete(string address)
		{
			var uri = baseUrl + "input=" + address + "&types=address";
			var response = await _client.GetAsync(uri).ConfigureAwait(false);
			var content = await response.Content.ReadAsStringAsync();
			return JObject.Parse(content);
		}
		public async Task<JObject> getDetailPlaceInfo(string id)
		{
			var urlDetail = "https://maps.googleapis.com/maps/api/place/details/json?key=AIzaSyCGgtCS6sS-WQRopBTWBE_7lJ5phxncZog&";
			var uri = urlDetail + "placeid=" + id;
			var response = await _client.GetAsync(uri).ConfigureAwait(false);
			var content = await response.Content.ReadAsStringAsync();
			return JObject.Parse(content);
		}
	}
}
