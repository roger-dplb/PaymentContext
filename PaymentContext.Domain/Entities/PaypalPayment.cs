using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PaypalPayment(
    DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    Document document,
    string payer,
    Address address,
    Email email,
    string transactionCode) : Payment(paidDate, expireDate, total, totalPaid, document, payer, address, email)
{
    public string TransactionCode { get; private set; } = transactionCode;
}