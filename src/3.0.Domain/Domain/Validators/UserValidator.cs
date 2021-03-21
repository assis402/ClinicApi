using FluentValidation;
using Domain.Entities;
using Presentation.Utils.Messages;
using Presentation.Utils;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC001(nameof(User)))

                .NotNull()
                .WithMessage(ExceptionMessages.EXC002(nameof(User)));

            RuleFor(x => x.TaxNumber)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC003(nameof(User.TaxNumber)))

                .NotNull()
                .WithMessage(ExceptionMessages.EXC004(nameof(User.TaxNumber)))

                .Length(11)
                .WithMessage(ExceptionMessages.EXC013(nameof(User.TaxNumber),11))

                .Must(x => UsefulFunctions.IsValidCPF(x))
                .WithMessage(ExceptionMessages.EXC007(nameof(User.TaxNumber)));

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC003(nameof(User.Password)))

                .NotNull()
                .WithMessage(ExceptionMessages.EXC004(nameof(User.Password)))

                .MinimumLength(10)
                .WithMessage(ExceptionMessages.EXC005(nameof(User.Password),10))

                .MaximumLength(30)
                .WithMessage(ExceptionMessages.EXC006(nameof(User.Password),30));

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC003(nameof(User.Name)))

                .NotNull()
                .WithMessage(ExceptionMessages.EXC004(nameof(User.Name)))

                .MinimumLength(3)
                .WithMessage(ExceptionMessages.EXC005(nameof(User.Name),3))

                .MaximumLength(180)
                .WithMessage(ExceptionMessages.EXC006(nameof(User.Name),180));

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC003(nameof(User.Email)))

                .NotNull()
                .WithMessage(ExceptionMessages.EXC004(nameof(User.Email)))

                .MinimumLength(6)
                .WithMessage(ExceptionMessages.EXC005(nameof(User.Email),6))

                .MaximumLength(180)
                .WithMessage(ExceptionMessages.EXC006(nameof(User.Email),180))

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage(ExceptionMessages.EXC007(nameof(User.Email)));

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC003(nameof(User.PhoneNumber)))

                .NotNull()
                .WithMessage(ExceptionMessages.EXC004(nameof(User.PhoneNumber)))

                .Length(11)
                .WithMessage(ExceptionMessages.EXC013(nameof(User.PhoneNumber),11));

            RuleFor(x => x.ClinicalUnitId)
                .NotEmpty()
                .WithMessage(ExceptionMessages.EXC003(nameof(Base.Id)))

                .NotNull()
                .WithMessage(ExceptionMessages.EXC004(nameof(Base.Id)))
                
                .LessThan(100001)
                .WithMessage(ExceptionMessages.EXC013(nameof(Base.Id),6));
        }
    }
}