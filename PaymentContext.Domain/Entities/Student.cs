using PaymentContext.Common.Entities;
using PaymentContext.Domain.ValueObjects;
using ErrorOr;
using PaymentContext.Domain.Errors;

namespace PaymentContext.Domain.Entities;

public class Student(Name name, Document document, Email email) : Entity
{
    private readonly List<Subscription> _subscriptions = [];

    public Name Name { get; private set; } = name;
    public Document Document { get; private set; } = document;
    public Email Email { get; private set; } = email;
    public Address? Address { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.AsReadOnly();
    public List<Payment> Payments { get; } = [];
    public void SetAddress(Address address) => Address = address;

    public ErrorOr<Success> AddSubscription(Subscription subscription)
    {
        if (_subscriptions.Any(s => s.Active))
        {
            return SubscriptionErrors.HasSubscriptionActive;
        }

        _subscriptions.Add(subscription);
        return Result.Success;
    }
}
