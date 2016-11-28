using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BigBreakers
{
	public partial class PhotoCell : ViewCell
	{
		public static readonly BindableProperty ImageProperty =
			BindableProperty.Create("Image", typeof(ImageSource), typeof(EntryFormCell), null);

		public static readonly BindableProperty LabelProperty =
			BindableProperty.Create(
				"Label", typeof(string), typeof(EntryFormCell), default(string));

		[TypeConverter(typeof(ImageSourceConverter))]
		public ImageSource Image
		{
			get { return (ImageSource)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}


		public string Label
		{
			set { SetValue(LabelProperty, value); }
			get { return (string)GetValue(LabelProperty); }
		}


		public PhotoCell()
		{
			InitializeComponent();
		}
	}
}
