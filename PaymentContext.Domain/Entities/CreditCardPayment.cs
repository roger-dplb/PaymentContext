using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment(
    DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    Document document,
    string payer,
    Address address,
    Email email,
    string holderName,
    string lastDigits,
    string paymentAddress) : Payment(paidDate, expireDate, total, totalPaid, document, payer, address, email)
{
    public string HolderName { get; private set; } = holderName;
    public string LastDigits { get; private set; } = lastDigits;
    public string PaymentAddress { get; private set; } = paymentAddress;
}