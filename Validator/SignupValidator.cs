using System;
using FluentValidation;

namespace BigBreakers
{
	public class SignupValidator: AbstractValidator<UserModel>
	{
		public SignupValidator()
		{
			RuleFor(user => user.publicData).SetValidator(new UserPublicDataValidator());
			RuleFor(user => user.phoneNumber).NotEmpty().WithMessage("Veuillez rentrer un numéro de téléphone valide");
			RuleFor(user => user.Username).NotEmpty().Length(3, 50).EmailAddress().WithMessage("Veuillez rentrer un email valide");
		}
	}
}
