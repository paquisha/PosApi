using FluentValidation;
using POS.Application.Dtos.User.Request;
using POS.Utilities.Static;

namespace POS.Application.Validators.User
{
    public class UserValidator : AbstractValidator<UserRequestDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage(ReplyMessage.MESSAGE_EMPTY);
        }
    }
}