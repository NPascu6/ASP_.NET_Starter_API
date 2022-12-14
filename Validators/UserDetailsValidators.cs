using ASP_CORE_BASIC_NET_6_API.Models.DTOs;
using FluentValidation;

namespace ASP_CORE_BASIC_NET_6_API.Validators
{
    public class UserDetailsValidators: AbstractValidator<UserDetailsDTO>
    {
        public UserDetailsValidators()
        {
            RuleFor(x => x != null);
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.UserRole).NotEmpty();
            RuleFor(x => x.PhoneNumber > 0);
        }
    }
}
