namespace PaymentContext.Domain.Entities;

public abstract class Payment(
    DateTime paidDate,
    DateTime expireDate,
    decimal total,
    decimal totalPaid,
    string document,
    string payer,
    string address,
    string email)
{
    public string Number { get; private set; } = Guid.NewGuid().ToString().Replace("-", "")[..10].ToUpper();
    public DateTime PaidDate { get; private set; } = paidDate;
    public DateTime ExpireDate { get; private set; } = expireDate;
    public decimal Total { get; private set; } = total;
    public decimal TotalPaid { get; private set; } = totalPaid;
    public string Document { get; private set; } = document;
    public string Payer { get; private set; } = payer;
    public string Address { get; private set; } = address;
    public string Email { get; private set; } = email;
}