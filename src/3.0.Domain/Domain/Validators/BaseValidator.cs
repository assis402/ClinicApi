using FluentValidation;
using Domain.Entities;
using Presentation.Utils.Messages;
using Presentation.Utils;

namespace Domain.Validators
{
    public class BaseValidator : AbstractValidator<Base>
    {
        public BaseValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Base.Id)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Base.Id)))
                
                .LessThan(100001)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(Base.Id),6));

            RuleFor(x => x.CreationDate)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Base.CreationDate)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Base.CreationDate)));
            
            RuleFor(x => x.UpdateDate)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Base.CreationDate)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Base.CreationDate)));

            RuleFor(x => x.DeletionDate)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Base.CreationDate)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Base.CreationDate)));
        }
    }
}