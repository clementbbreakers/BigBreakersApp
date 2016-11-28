using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Plugin.Toasts;
using Parse;
using ImageCircle.Forms.Plugin.Droid;

namespace BigBreakers.Droid
{
	[Activity(Label = "BigBreakers.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;
			base.OnCreate(bundle);
			Xamarin.FormsGoogleMaps.Init(this, bundle);
			ImageCircleRenderer.Init();
			DependencyService.Register<ToastNotificatorImplementation>();
			ToastNotificatorImplementation.Init(this);
			global::Xamarin.Forms.Forms.Init(this, bundle);
			ParseClient.Initialize(new ParseClient.Configuration
			{
				ApplicationId = "myAppId",
				Server = "http://bigbreakers.herokuapp.com/parse/" // trailing slash is important
			});
			ParseFacebookUtils.Initialize("1790522011216423");
			LoadApplication(new App());
		}
	}
}

