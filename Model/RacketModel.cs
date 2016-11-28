using System;
using Parse;

namespace BigBreakers
{
	[ParseClassName("Racket")]
	public class RacketModel : ParseObject
	{
		[ParseFieldName("model")]
		public string model
		{
			get { return GetProperty<string>(); }
			set { SetProperty(value); }
		}
		[ParseFieldName("brand")]
		public BrandModel brand
		{
			get { return GetProperty<BrandModel>(); }
			set { SetProperty(value); }
		}
	}
}
