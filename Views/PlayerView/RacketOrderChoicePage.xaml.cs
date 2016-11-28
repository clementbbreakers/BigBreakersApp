using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BigBreakers
{
	public partial class RacketOrderChoicePage : ContentPage
	{
		private RacketOrderChoiceViewModel _vm;
		public RacketOrderChoicePage()
		{
			InitializeComponent();
			_vm = App.Locator.RacketOrder;
			this.BindingContext = _vm;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_vm.getRacketsDetail();
		}
	}
}
