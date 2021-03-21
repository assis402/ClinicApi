using FluentValidation;
using Presentation.Utils.Messages;
using Presentation.Utils.JsonModels.Models.ClinicalUnitController;
using System.Collections.Generic;

namespace Presentation.Utils.JsonModels.Validators
{
    public class JsonPostValidator : AbstractValidator<JsonPost>
    {
        List<string> Errors = new List<string>();

        public JsonPostValidator()
        {
            Errors[0] = ExceptionMessages.EXC011();
            Errors[1] = ExceptionMessages.EXC012();
            Errors[2] = ExceptionMessages.EXC003(nameof(JsonPost.CompanyName));
            Errors[3] = ExceptionMessages.EXC004(nameof(JsonPost.CompanyName));
            Errors[4] = ExceptionMessages.EXC003(nameof(JsonPost.TaxNumber));
            Errors[5] = ExceptionMessages.EXC004(nameof(JsonPost.TaxNumber));
            Errors[6] = ExceptionMessages.EXC013(nameof(JsonPost.TaxNumber),11));
            Errors[7] = ExceptionMessages.EXC007(nameof(JsonPost.TaxNumber));

            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(Errors[0])

                .NotNull()
                .WithMessage(Errors[1]);

            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .WithMessage(Errors[2])

                .NotNull()
                .WithMessage(Errors[3]);

            RuleFor(x => x.TaxNumber)
                .NotEmpty()
                .WithMessage(Errors[4])

                .NotNull()
                .WithMessage(Errors[5])

                .Length(11)
                .WithMessage(Errors[6])

                .When(x => x.TaxNumber.Length == 11)
                .Must(x => UsefulFunctions.IsValidCPF(x))
                .WithMessage(Errors[7])

                .When(x => x.TaxNumber.Length == 14)
                .Must(x => UsefulFunctions.IsValidCNPJ(x))
                .WithMessage(Errors[7]);
        }
    }
}
