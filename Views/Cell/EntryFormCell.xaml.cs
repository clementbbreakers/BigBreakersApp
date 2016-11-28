using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BigBreakers
{
	public partial class EntryFormCell : ViewCell
	{
		public static readonly BindableProperty ImageProperty =
			BindableProperty.Create("Image", typeof(ImageSource), typeof(EntryFormCell),null);
		
		public static readonly BindableProperty TitleProperty =
			BindableProperty.Create(
				"PlaceHolder", typeof(string), typeof(EntryFormCell), default(string));
		
		public static readonly BindableProperty LabelProperty =
			BindableProperty.Create(
				"Label", typeof(string), typeof(EntryFormCell), default(string));

		public static readonly BindableProperty TextProperty =
			BindableProperty.Create(
				"Text", typeof(string), typeof(EntryFormCell), default(string));

		[TypeConverter(typeof(ImageSourceConverter))]
		public ImageSource Image
		{
			get { return (ImageSource)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value);}
		}

		public string PlaceHolder
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		public string Label
		{
			set { SetValue(LabelProperty, value); }
			get { return (string)GetValue(LabelProperty); }
		}

		public string Text
		{
			set { SetValue(TextProperty, value); }
			get { return (string)GetValue(TextProperty); }
		}

		public EntryFormCell()
		{
			InitializeComponent();
		}
	}
}
