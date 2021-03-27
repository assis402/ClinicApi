using FluentValidation;
using Domain.Entities;
using Presentation.Utils.Messages;

namespace Domain.Validators
{
    public class SpecialtyValidator : AbstractValidator<Specialty>
    {
        public SpecialtyValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC001(),nameof(Specialty)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC002(),nameof(Specialty)));

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Specialty.Title)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Specialty.Title)))

                .MinimumLength(3)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(Specialty.Title),3))

                .MaximumLength(180)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(Specialty.Title),180));

            RuleFor(x => x.ClinicalUnitId)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Specialist.ClinicalUnitId)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Specialist.ClinicalUnitId)))

                .LessThan(100001)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(Base.Id),6));
        }
    }
}