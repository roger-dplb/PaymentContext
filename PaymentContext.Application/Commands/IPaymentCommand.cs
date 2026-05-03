using PaymentContext.Domain.Enums;

namespace PaymentContext.Application.Commands;

public interface IPaymentCommand
{
    EDocumentType PayerDocumentType { get; }
    string PayerEmail { get; }
    string Street { get; }
    string AddressNumber { get; }
    string Neighborhood { get; }
    string City { get; }
    string State { get; }
    string Country { get; }
    string ZipCode { get; }
    string Payer { get; }
    DateTime PaidDate { get; }
    DateTime ExpireDate { get; }
    decimal Total { get; }
    decimal TotalPaid { get; }
}
