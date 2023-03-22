using FluentValidation;

namespace Market.Models
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.FullName).NotEmpty().NotNull().Length(5, 255);
            RuleFor(user => user.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(user => user.UserName).NotNull().NotEmpty().MinimumLength(5).MaximumLength(100);
            RuleFor(user => user.Password).NotNull().NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(user => user.Phone).NotNull().NotEmpty();
        }


    }
}
