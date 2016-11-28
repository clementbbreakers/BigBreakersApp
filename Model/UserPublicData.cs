using System;
using System.Collections.Generic;
using Parse;

namespace BigBreakers
{
	[ParseClassName("UserPublicData")]
	public class UserPublicData : ParseObject
	{
		[ParseFieldName("firstName")]
		public string firstName
		{
			get { return GetProperty<string>();}
			set { SetProperty(value);}
		}
		[ParseFieldName("lastName")]
		public string lastName
		{
			get { return GetProperty<string>(); }
			set { SetProperty(value); }
		}
		[ParseFieldName("phoneVerified")]
		public bool phoneVerified
		{
			get { return GetProperty<bool>();}
			set { SetProperty(value); }
		}
		[ParseFieldName("type")]
		public string type
		{
			get { return GetProperty<string>(); }
			set { SetProperty(value); }
		}
		[ParseFieldName("gender")]
		public string gender
		{
			get { return GetProperty<string>(); }
			set { SetProperty(value); }
		}
		[ParseFieldName("club")]
		public string club
		{
			get { return GetProperty<string>(); }
			set { SetProperty(value); }
		}
		[ParseFieldName("rank")]
		public string rank
		{
			get { return GetProperty<string>(); }
			set { SetProperty(value); }
		}
		[ParseFieldName("rackets")]
		public List<RacketModel> rackets
		{
			get { return GetProperty<List<RacketModel>>(); }
			set { SetProperty(value); }
		}
		[ParseFieldName("profilePicture")]
		public ParseFile profilePicture
		{
			get { return GetProperty<ParseFile>(); }
			set { SetProperty(value); }
		}
	}
}
