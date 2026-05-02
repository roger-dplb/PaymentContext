namespace PaymentContext.Domain.Entities;

public class Subscription(DateTime? expirationDate)
{
    private readonly IList<Payment> _payments = new List<Payment>();

    public DateTime CreateDate { get; private set; } = DateTime.Now;
    public DateTime LastUpdateDate { get; private set; } = DateTime.Now;
    public DateTime? ExpirationDate { get; private set; } = expirationDate;
    public IReadOnlyCollection<Payment> Payments => _payments.ToArray();
    public bool Active { get; private set; } = true;

    public void AddPayment(Payment payment)
    {
        _payments.Add(payment);
    }

    public void Deactivate()
    {
        Active = false;
        LastUpdateDate = DateTime.Now;
    }

    public void Activate()
    {
        Active = true;
        LastUpdateDate = DateTime.Now;
    }
}