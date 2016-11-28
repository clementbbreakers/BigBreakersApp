using System;
using FluentValidation;

namespace BigBreakers
{
	public class PrivateProfileValidator:AbstractValidator<UserPublicData>
	{
		public PrivateProfileValidator()
		{
			RuleFor(data => data.gender).NotEmpty().WithMessage("Vous devez définir votre sexe");
		}
	}
}
