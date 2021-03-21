using FluentValidation;
using Domain.Entities;
using Presentation.Utils.Messages;
using Presentation.Utils;

namespace Domain.Validators
{
    public class ClinicalUnitValidator : AbstractValidator<ClinicalUnit>
    {
        public ClinicalUnitValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC001(nameof(ClinicalUnit)))

                .NotNull()
                .WithMessage(ExceptionMessages.EXC002(nameof(ClinicalUnit)));

            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC003(nameof(ClinicalUnit.CompanyName)))

                .NotNull()
                .WithMessage(ExceptionMessages.EXC004(nameof(ClinicalUnit.CompanyName)))

                .MinimumLength(3)
                .WithMessage(ExceptionMessages.EXC005(nameof(ClinicalUnit.CompanyName),3))

                .MaximumLength(180)
                .WithMessage(ExceptionMessages.EXC006(nameof(ClinicalUnit.CompanyName),180));

            RuleFor(x => x.TaxNumber)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC003(nameof(User.TaxNumber)))

                .NotNull()
                .WithMessage(ExceptionMessages.EXC004(nameof(User.TaxNumber)))

                .Length(11)
                .WithMessage(ExceptionMessages.EXC013(nameof(User.TaxNumber),11))

                .When(x => x.TaxNumber.Length == 11)
                .Must(x => UsefulFunctions.IsValidCPF(x))
                .WithMessage(ExceptionMessages.EXC007(nameof(User.TaxNumber)))

                .When(x => x.TaxNumber.Length == 14)
                .Must(x => UsefulFunctions.IsValidCNPJ(x))
                .WithMessage(ExceptionMessages.EXC007(nameof(User.TaxNumber)));
        }
    }
}
