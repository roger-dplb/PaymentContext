using PaymentContext.Domain.Enums;

namespace PaymentContext.Application.Commands;

public record CreatePaypalPaymentCommand(
    // Dados do pagador
    EDocumentType PayerDocumentType,
    string PayerEmail,

    // Endereço (vão virar Address VO)
    string Street,
    string AddressNumber,
    string Neighborhood,
    string City,
    string State,
    string Country,
    string ZipCode,

    // Dados do pagamento
    string Payer,
    DateTime PaidDate,
    DateTime ExpireDate,
    decimal Total,
    decimal TotalPaid,

    // Específico do Paypal
    string TransactionCode) : IPaymentCommand;
