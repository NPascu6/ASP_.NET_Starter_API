using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using FluentValidation;

namespace ASP_CORE_BASIC_NET_6_API.Validators
{
    public class UserValidators: AbstractValidator<UserDTO>
    {
        public UserValidators()
        {
            RuleFor(x => x != null);
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
