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
                .WithMessage(string.Format(ExceptionMessages.EXC001(),nameof(User)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC002(),nameof(User)));

            RuleFor(x => x.TaxNumber)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(User.TaxNumber)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(User.TaxNumber)))

                .Length(11)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(User.TaxNumber),11))

                .Must(x => UsefulFunctions.IsValidCPF(x))
                .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(User.TaxNumber)));

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(User.Password)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(User.Password)))

                .MinimumLength(10)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(User.Password),10))

                .MaximumLength(30)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(User.Password),30));

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(User.Name)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(User.Name)))

                .MinimumLength(3)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(User.Name),3))

                .MaximumLength(180)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(User.Name),180));

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(User.Email)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(User.Email)))

                .MinimumLength(6)
                .WithMessage(string.Format(ExceptionMessages.EXC005(),nameof(User.Email),6))

                .MaximumLength(180)
                .WithMessage(string.Format(ExceptionMessages.EXC006(),nameof(User.Email),180))

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage(string.Format(ExceptionMessages.EXC007(),nameof(User.Email)));

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage(string.Format(ExceptionMessages.EXC003(),nameof(User.PhoneNumber)))

                .NotNull()
                .WithMessage(string.Format(ExceptionMessages.EXC004(),nameof(User.PhoneNumber)))

                .Length(11)
                .WithMessage(string.Format(ExceptionMessages.EXC013(),nameof(User.PhoneNumber),11));
        }
    }
}