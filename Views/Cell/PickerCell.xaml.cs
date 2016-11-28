using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BigBreakers
{
	[ContentProperty("Items")]
	public partial class PickerCell : ViewCell
	{
		public static readonly BindableProperty ImageProperty =
			BindableProperty.Create("Image", typeof(ImageSource), typeof(EntryFormCell), null);

		public static readonly BindableProperty TitleProperty =
			BindableProperty.Create(
				"PlaceHolder", typeof(string), typeof(EntryFormCell), default(string));

		public static readonly BindableProperty LabelProperty =
			BindableProperty.Create(
				"Label", typeof(string), typeof(EntryFormCell), default(string));


		[TypeConverter(typeof(ImageSourceConverter))]
		public ImageSource Image
		{
			get { return (ImageSource)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
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


		public IList<string> Items
		{
			get { return picker.Items; }
		}

		public string SelectedValue
		{
			get { return (string)GetValue(SelectedValueProperty); }
			set { SetValue(SelectedValueProperty, value); }
		}

		public static readonly BindableProperty SelectedValueProperty =
			BindableProperty.Create(
				"SelectedValue", typeof(string), typeof(PickerCell), null,
				BindingMode.TwoWay,
				propertyChanged: (sender, oldValue, newValue) =>
					{
						PickerCell pickerCell = (PickerCell)sender;

						if (String.IsNullOrEmpty((string)newValue))
						{
							pickerCell.picker.SelectedIndex = -1;
						}
						else
						{
							pickerCell.picker.SelectedIndex =
									pickerCell.Items.IndexOf((string)newValue);
						}
					});

		public PickerCell()
		{
			InitializeComponent();
		}

		void OnPickerSelectedIndexChanged(object sender, EventArgs args)
		{
			if (picker.SelectedIndex == -1)
			{
				SelectedValue = null;
			}
			else
			{
				SelectedValue = Items[picker.SelectedIndex];
			}
		}

	}
}
