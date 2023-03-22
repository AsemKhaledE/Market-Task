using FluentValidation;
using Market.ViewModel;

namespace Market.ModelValidation
{
    public class UserValidator:AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(user => user.FullName).NotEmpty().NotNull().Length(5, 255);
            RuleFor(user => user.Email).EmailAddress().NotEmpty().NotNull().MinimumLength(15).MaximumLength(100); ;
            RuleFor(user => user.UserName).NotNull().NotEmpty().MinimumLength(10).MaximumLength(100);
            RuleFor(user => user.Password).NotNull().NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(user => user.Phone).NotNull().NotEmpty();
        }


    }
}
