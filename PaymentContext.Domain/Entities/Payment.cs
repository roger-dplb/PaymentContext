using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public abstract class Payment(
    DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    Document document,
    string payer,
    Address address,
    Email email)
{
    public string Number { get; private set; } = Guid.NewGuid().ToString().Replace("-", "")[..10].ToUpper();
    public DateTime PaidDate { get; private set; } = paidDate;
    public DateTime ExpireDate { get; private set; } = expireDate;
    public decimal Total { get; private set; } = total;
    public decimal TotalPaid { get; private set; } = totalPaid;
    public Document Document { get; private set; } = document;
    public string Payer { get; private set; } = payer;
    public Address Address { get; private set; } = address;
    public Email Email { get; private set; } = email;
}