using System;
using BigBreakers;
using BigBreakers.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryForm), typeof(EntryFormRenderer))]
namespace BigBreakers.Droid
{
	class EntryFormRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
				Control.Gravity = Android.Views.GravityFlags.Right;
			}
		}
	}
}