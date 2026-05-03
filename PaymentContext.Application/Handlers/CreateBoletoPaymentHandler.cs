using ErrorOr;
using MediatR;
using PaymentContext.Application.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Application.Handlers;

public class CreateBoletoPaymentHandler
    : IRequestHandler<CreateBoletoPaymentCommand, ErrorOr<BoletoPayment>>
{
    public Task<ErrorOr<BoletoPayment>> Handle(
        CreateBoletoPaymentCommand cmd,
        CancellationToken cancellationToken)
    {
        // 1. Constrói os Value Objects a partir dos primitivos do Command.
        var errors = new List<Error>();

        var documentResult = Document.Create(cmd.PayerDocumentNumber, cmd.PayerDocumentType);
        if (documentResult.IsError)
        {
            errors.AddRange(documentResult.Errors);
        }

        var emailResult = Email.Create(cmd.PayerEmail);
        if (emailResult.IsError)
        {
            errors.AddRange(emailResult.Errors);
        }

        var addressResult = Address.Create(
            cmd.Street,
            cmd.AddressNumber,
            cmd.Neighborhood,
            cmd.City,
            cmd.State,
            cmd.Country,
            cmd.ZipCode);
        if (addressResult.IsError)
        {
            errors.AddRange(addressResult.Errors);
        }

        if (errors.Count > 0)
        {
            return Task.FromResult<ErrorOr<BoletoPayment>>(errors);
        }

        // 2. Compõe PaymentDetails com os VOs já validados.
        var details = new PaymentDetails(
            cmd.PaidDate,
            cmd.ExpireDate,
            cmd.Total,
            cmd.TotalPaid,
            documentResult.Value,
            cmd.Payer,
            addressResult.Value,
            emailResult.Value);

        // 3. Smart Constructor da entidade (valida invariantes do Payment).
        var paymentResult = BoletoPayment.Create(details, cmd.BarCode);
        if (paymentResult.IsError)
        {
            return Task.FromResult<ErrorOr<BoletoPayment>>(paymentResult.Errors);
        }

        // 4. (próximo) — persistir via Repository:
        // await _repository.AddAsync(paymentResult.Value, ct);
        // await _repository.SaveChangesAsync(ct);

        return Task.FromResult<ErrorOr<BoletoPayment>>(paymentResult.Value);
    }
}
