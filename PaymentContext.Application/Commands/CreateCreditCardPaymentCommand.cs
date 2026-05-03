using PaymentContext.Domain.Enums;

namespace PaymentContext.Application.Commands;

public record CreateCreditCardPaymentCommand(
    // Dados do pagador (vão virar Document, Email, Address VOs)
    string PayerDocumentNumber,
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

    //Dados do cartao de credito
    string LastFourDigits,
    string PaymentAddress,
    string HolderName
) : IPaymentCommand;
