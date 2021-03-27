using FluentValidation;
using Domain.Entities;
using Presentation.Utils.Messages;

namespace Domain.Validators
{
    public class SpecialistValidator : AbstractValidator<Specialist>
    {
        public SpecialistValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC001(),nameof(Specialist)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC002(),nameof(Specialist)));

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Specialist.Name)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Specialist.Name)))

                .MinimumLength(3)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(Specialist.Name),3))

                .MaximumLength(180)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(Specialist.Name),180));

            RuleFor(x => x.Formation.ToString())
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Specialist.Specialty)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Specialist.Specialty)))

                .Length(6)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(Specialist.Specialty),6));

            RuleFor(x => x.Specialty)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(Specialist.Specialty)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(Specialist.Specialty)))

                .Length(6)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(Specialist.Specialty),6));

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