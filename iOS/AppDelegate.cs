using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Plugin.Toasts;
using Parse;
using Syncfusion.SfAutoComplete.XForms.iOS;
using ImageCircle.Forms.Plugin.iOS;

namespace BigBreakers.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			DependencyService.Register<ToastNotificatorImplementation>();
			ToastNotificatorImplementation.Init();
			global::Xamarin.Forms.Forms.Init();
			ImageCircleRenderer.Init();
			new SfAutoCompleteRenderer();
			ParseClient.Initialize(new ParseClient.Configuration
			{
				ApplicationId = "myAppId",
				Server = "http://bigbreakers.herokuapp.com/parse/" // trailing slash is important
			});
			ParseFacebookUtils.Initialize("1790522011216423");
			LoadApplication(new App());
			Xamarin.FormsGoogleMaps.Init("AIzaSyC6MmgY1vrl6B71IRKJKL9cLdfVBJssHfA");
			return base.FinishedLaunching(app, options);
		}
	}
}

