using Xamarin.Forms.Platform.iOS;
using System;
using Xamarin.Forms;
using BigBreakers;
using BigBreakers.iOS;

[assembly: ExportRenderer(typeof(EntryForm), typeof(EntryFormRenderer))]
namespace BigBreakers.iOS
{
	public class EntryFormRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.BorderStyle = UIKit.UITextBorderStyle.None;
				Control.TextAlignment = UIKit.UITextAlignment.Right;
			}
		}
	}
}
