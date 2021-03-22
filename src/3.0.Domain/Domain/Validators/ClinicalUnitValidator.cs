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
                .WithMessage(ExceptionMessages.EXC011())

                .NotNull()
                .WithMessage(ExceptionMessages.EXC012());

            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(ClinicalUnit.CompanyName)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(ClinicalUnit.CompanyName)))

                .MinimumLength(3)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(ClinicalUnit.CompanyName),3))

                .MaximumLength(180)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(ClinicalUnit.CompanyName),180));

            RuleFor(x => x.TaxNumber)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(ClinicalUnit.TaxNumber)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(ClinicalUnit.TaxNumber)))

                .When(x => x.TaxNumber.Length != 11 && x.TaxNumber.Length != 14)
                .WithMessage(string.Format(ExceptionMessages.EXC015(),nameof(ClinicalUnit.TaxNumber)))

                .When(x => x.TaxNumber.Length == 11)
                //.Must(x => UsefulFunctions.IsValidCPF(x))
                .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(ClinicalUnit.TaxNumber)))

                .When(x => x.TaxNumber.Length == 14)
                .Must(x => UsefulFunctions.IsValidCNPJ(x))
                .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(ClinicalUnit.TaxNumber)));
        }
    }
}
