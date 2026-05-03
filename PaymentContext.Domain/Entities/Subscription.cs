using ErrorOr;
using PaymentContext.Common.Entities;
using PaymentContext.Domain.Errors;

namespace PaymentContext.Domain.Entities;

public class Subscription(DateTime? expirationDate) : Entity
{
    private readonly List<Payment> _payments = [];

    public DateTime CreateDate { get; private set; } = DateTime.Now;
    public DateTime LastUpdateDate { get; private set; } = DateTime.Now;
    public DateTime? ExpirationDate { get; private set; } = expirationDate;
    public IReadOnlyCollection<Payment> Payments => _payments.ToArray();
    public bool Active { get; private set; } = true;

    public ErrorOr<Success> AddPayment(Payment payment)
    {
        if (payment.PaidDate < DateTime.Now)
        {
            return PaymentErrors.InvalidPaidDate;
        }
        //TODO ADD OTHER VALIDATIONS

        _payments.Add(payment);
        return Result.Success;
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
