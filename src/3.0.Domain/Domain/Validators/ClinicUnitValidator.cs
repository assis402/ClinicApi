using FluentValidation;
using Domain.Entities;

namespace Domain.Validators
{
    public class ClinicUnitValidator : AbstractValidator<ClinicUnit>
    {
        public ClinicUnitValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");
        }
    }
}
