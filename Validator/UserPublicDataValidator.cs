using System;
using FluentValidation;

namespace BigBreakers
{
	public class UserPublicDataValidator : AbstractValidator<UserPublicData>
	{
		public UserPublicDataValidator()
		{
			RuleFor(data => data.firstName).NotEmpty().WithMessage("Veuillez indiquer votre prénom");
			RuleFor(data => data.lastName).NotEmpty().WithMessage("Veuillez indiquer votre nom");
		}
	}
}
