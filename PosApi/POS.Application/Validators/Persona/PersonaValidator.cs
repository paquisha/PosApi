using FluentValidation;
using POS.Application.Dtos.Persona.Request;
using POS.Utilities.Static;

namespace POS.Application.Validators.Persona
{
    public class PersonaValidator : AbstractValidator<PersonaRequestDto>
    {
        public PersonaValidator()
        {
            RuleFor(x => x.FirtsName).NotEmpty().WithMessage(ReplyMessage.MESSAGE_EMPTY);
            RuleFor(x => x.LastName).NotEmpty().WithMessage(ReplyMessage.MESSAGE_EMPTY);
            RuleFor(x => x.Email).NotEmpty().WithMessage(ReplyMessage.MESSAGE_EMPTY);
        }
    }
}
