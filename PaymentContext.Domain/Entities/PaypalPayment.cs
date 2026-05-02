namespace PaymentContext.Domain.Entities;

public class PaypalPayment(
    DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    string document,
    string payer,
    string address,
    string email,
    string transactionCode) : Payment(paidDate, expireDate, total, totalPaid, document, payer, address, email)
{
    public string TransactionCode { get; private set; } = transactionCode;
}