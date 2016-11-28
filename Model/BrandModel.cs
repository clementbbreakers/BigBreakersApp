using System;
using Parse;

namespace BigBreakers
{
	[ParseClassName("Brand")]
	public class BrandModel : ParseObject
	{
		[ParseFieldName("name")]
		public string name
		{
			get { return GetProperty<string>(); }
			set { SetProperty(value); }
		}
	}
}
