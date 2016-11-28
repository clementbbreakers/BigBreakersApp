using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Parse;
using System.IO;

namespace BigBreakers
{
	public partial class PrivateProfileTablePage : ContentPage
	{
		private PrivateProfilePlayerViewModel _vm;
		public PrivateProfileTablePage(bool fromTabBar = false)
		{
			InitializeComponent();
			_vm = App.Locator.ProfilePlayer;
			this.BindingContext = _vm;
			_vm.fromTabBar = fromTabBar;
			skipButton.IsVisible = !fromTabBar;
			MessagingCenter.Subscribe<ParseFile>(this, "setProfilePicture", (obj) =>
			{
				if (obj != null)
				{
					PictureCell.Image = new UriImageSource { Uri = obj.Url };
				}
			});
			skipButton.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new RacketChoicePage());
			};
			PictureCell.Tapped += async (object sender, EventArgs e) =>
			{
				await CrossMedia.Current.Initialize();
				var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
				{
					PhotoSize = PhotoSize.Small
				});
				if (file != null)
				{
					//ParseFile savePicture;
					//var fileStream = file.GetStream();
					//savePicture = new ParseFile("image.png", fileStream);
					PictureCell.Image = ImageSource.FromStream(() => 
					{
						var stream = file.GetStream();
						file.Dispose();
						return stream;
					});
					using (var memoryStream = new MemoryStream())
					{
						file.GetStream().CopyTo(memoryStream);
						var data = new Dictionary<string, object>();
						data["array"] = memoryStream.ToArray();
						var response = await ParseCloud.CallFunctionAsync<ParseFile>("saveProfilePicture", data);
						_vm.setProfilePicture(response);
					}
				}

			};
			genderCell.Items.Add("Homme");
			genderCell.Items.Add("Femme");
		}
	}
}
