using PaymentContext.Application.Commands;

namespace PaymentContext.Application.Validators;

using FluentValidation;

public class CreatePaypalPaymentCommandValidator : PaymentCommandValidator<CreatePaypalPaymentCommand>
{
    public CreatePaypalPaymentCommandValidator()
    {
        RuleFor(c => c.TransactionCode)
            .NotEmpty();
    }
}
