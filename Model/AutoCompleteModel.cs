using System;
namespace BigBreakers
{
	public class AutoCompleteModel
	{
		public AutoCompleteModel(string desc)
		{
			description = desc;
		}
		public string id { get; set; } 		public string description { get; set; }
		public string place_id { get; set; }
	}

}
