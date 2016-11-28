using System;
using System.Collections.Generic;
using BigBreakers;
using BigBreakers.iOS;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Parse;

[assembly: ExportRenderer(typeof(FacebookLoginPage), typeof(FacebookLoginRenderer))]
namespace BigBreakers.iOS
{
	public class FacebookLoginRenderer : PageRenderer
	{
		int count = 0;
		public override void ViewDidLoad()
		{
			count++;
			base.ViewDidLoad();
		}
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			var auth = new OAuth2Authenticator(
				clientId: "1790522011216423", // your OAuth2 client id
				scope: "email", // the scopes for the particular API you're accessing, delimited by "+" symbols
				authorizeUrl: new Uri("https://www.facebook.com/v2.8/dialog/oauth"), // the auth URL for the service
				redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")); // the redirect URL for the service

			auth.Completed += async (sender, eventArgs) =>
			{
				count++;
				// We presented the UI, so it's up to us to dimiss it on iOS.
				//App.SuccessfulLoginAction.Invoke();

				if (eventArgs.IsAuthenticated)
				{
					DismissViewController(true, null);
					var accessToken = eventArgs.Account.Properties["access_token"].ToString();
					var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
					var expireDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);

					var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=email,first_name,last_name,gender"), null, eventArgs.Account);
					var response = await request.GetResponseAsync();
					var obj = JObject.Parse(response.GetResponseText());
					var id = obj["id"].ToString().Replace("\"", "");
					await ParseFacebookUtils.LogInAsync(id, accessToken, expireDate);
					var session = await ParseSession.GetCurrentSessionAsync();
					var token = session.SessionToken;
					App.SuccessfulLoginAction.Invoke();
					App.SuccessFacebookLogin(token,obj);
				}
				else {
					// The user cancelled
				}
			};
			if (count <= 1)
			{
				PresentViewController(auth.GetUI(), true, null);
			}
		}
	}
}

