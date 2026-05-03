using FluentValidation;
using PaymentContext.Application.Commands;

namespace PaymentContext.Application.Validators;

public abstract class PaymentCommandValidator<TCommand> : AbstractValidator<TCommand> where TCommand : IPaymentCommand

{
    protected PaymentCommandValidator()
    {
        // Pagador
        RuleFor(c => c.PayerDocumentType).IsInEnum();
        RuleFor(c => c.PayerEmail).NotEmpty().MaximumLength(254);
        RuleFor(c => c.Payer).NotEmpty().MaximumLength(80);

        // Endereço
        RuleFor(c => c.Street).NotEmpty().MaximumLength(120);
        RuleFor(c => c.AddressNumber).NotEmpty().MaximumLength(10);
        RuleFor(c => c.Neighborhood).NotEmpty().MaximumLength(80);
        RuleFor(c => c.City).NotEmpty().MaximumLength(80);
        RuleFor(c => c.State).NotEmpty().MaximumLength(40);
        RuleFor(c => c.Country).NotEmpty().MaximumLength(40);
        RuleFor(c => c.ZipCode).NotEmpty().MaximumLength(20);

        // Pagamento
        RuleFor(c => c.Total).GreaterThan(0);
        RuleFor(c => c.TotalPaid).GreaterThan(0);
        RuleFor(c => c.PaidDate).NotEqual(default(DateTime));
        RuleFor(c => c.ExpireDate)
            .NotEqual(default(DateTime))
            .GreaterThan(c => c.PaidDate);
    }
}
