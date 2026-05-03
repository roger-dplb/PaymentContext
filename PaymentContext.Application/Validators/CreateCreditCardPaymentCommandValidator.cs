using System.Data;
using PaymentContext.Application.Commands;
using FluentValidation;

namespace PaymentContext.Application.Validators;

public class CreateCreditCardPaymentCommandValidator : PaymentCommandValidator<CreateCreditCardPaymentCommand>
{
    public CreateCreditCardPaymentCommandValidator()
    {
        RuleFor(c => c.HolderName)
            .NotEmpty()
            .MaximumLength(30);
        RuleFor(c => c.PaymentAddress)
            .NotEmpty()
            .MaximumLength(120);
        RuleFor(c => c.Payer)
            .NotEmpty()
            .MaximumLength(30);
    }
}
