using FluentValidation;
using Domain.Entities;
using Presentation.Utils.Messages;
using Presentation.Utils;

namespace Domain.Validators
{
    public class ProtocolValidator : AbstractValidator<Protocol>
    {
        public ProtocolValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC001(),nameof(Protocol)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC002(),nameof(Protocol)));

            RuleFor(x => x.ActionType.ToString())
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Protocol.ActionType)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Protocol.ActionType)))

                .Length(2)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(Protocol.ActionType),2));

            RuleFor(x => x.ProtocolNumber)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Protocol.ProtocolNumber)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Protocol.ProtocolNumber)))

                .Length(11)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(Protocol.ProtocolNumber),11));

            RuleFor(x => x.ClinicalUnitId)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Protocol.ClinicalUnitId)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Protocol.ClinicalUnitId)))

                .LessThan(100001)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(Base.Id),6));

            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Protocol.UserId)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Protocol.UserId)))

                .LessThan(100001)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(Base.Id),6));
        }
    }
}