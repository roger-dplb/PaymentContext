namespace PaymentContext.Domain.Entities;

public class CreditCardPayment(
    DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    string document,
    string payer,
    string address,
    string email,
    string holderName,
    string lastDigits,
    string paymentAddress) : Payment(paidDate, expireDate, total, totalPaid, document, payer, address, email)
{
    public string HolderName { get; private set; } = holderName;
    public string LastDigits { get; private set; } = lastDigits;
    public string PaymentAddress { get; private set; } = paymentAddress;
}