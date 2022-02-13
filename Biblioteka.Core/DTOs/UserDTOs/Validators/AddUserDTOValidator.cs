using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Biblioteka.Core
{
    public class AddUserDTOValidator : AbstractValidator<AddUserDTO>
    {
        private readonly IUserRepository _userRepository;

        public AddUserDTOValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(c => c.Email).NotEmpty().EmailAddress();

            RuleFor(c => c.PasswordHash).MinimumLength(8);

            RuleFor(c => c.ConfirmPassword).Equal(k => k.PasswordHash);

            RuleFor(c => c.Email).Custom((value, context) =>
            {
                var emailInUse = _userRepository.GetAll().Any(c => c.Email == value);
                if (emailInUse)
                {
                    context.AddFailure("Email", "That email address is taken.");
                }
            });
        }
    }
}
