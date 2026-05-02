using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment(
    DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    Document document,
    string payer,
    Address address,
    Email email,
    string barCode) : Payment(paidDate, expireDate, total, totalPaid, document, payer, address, email)
{
    public string BarCode { get; private set; } = barCode;

    public string BoletoNumber { get; private set; } =
        Guid.NewGuid().ToString().Replace("-", "")[..10].ToUpperInvariant();
}
