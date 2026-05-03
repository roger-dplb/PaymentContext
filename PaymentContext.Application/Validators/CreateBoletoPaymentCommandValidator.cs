using FluentValidation;
using PaymentContext.Application.Commands;

namespace PaymentContext.Application.Validators;

public class CreateBoletoPaymentCommandValidator
    : PaymentCommandValidator<CreateBoletoPaymentCommand>
{
    public CreateBoletoPaymentCommandValidator()
    {
        // Específico do Boleto
        RuleFor(c => c.BarCode)
            .NotEmpty()
            .MaximumLength(60);
    }
}
