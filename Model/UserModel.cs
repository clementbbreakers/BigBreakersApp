using System;
using Parse;

namespace BigBreakers
{
	[ParseClassName("_User")]
	public class UserModel : ParseUser
	{
		[ParseFieldName("phoneNumber")]
		public string phoneNumber
		{
			get { return GetProperty<string>();}
			set { SetProperty(value);}
		}
		[ParseFieldName("publicData")]
		public UserPublicData publicData
		{
			get { return GetProperty<UserPublicData>();}
			set { SetProperty(value); }
		}
		[ParseFieldName("phoneVerificationCode")]
		public string phoneVerificationCode
		{
			get { return GetProperty<string>(); }
		}
	}
}
