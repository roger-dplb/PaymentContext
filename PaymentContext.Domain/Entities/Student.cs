using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student(
    Name name,
    Document document,
    string email,
    string address,
    IList<Subscription> subscriptions) : Entity
{
    private readonly IList<Subscription> _subscriptions = subscriptions;
    public Name Name { get; private set; } = name;
    public Document Document { get; private set; } = document;
    public string Email { get; private set; } = email;
    public string Address { get; private set; } = address;

    public IReadOnlyCollection<Subscription> Subscriptions => _subscriptions.ToArray();


    public List<Payment> Payments { get; set; } = [];

    public void AddSubscription(Subscription subscription)
    {
        foreach (var subs in Subscriptions) subs.Deactivate();
        _subscriptions.Add(subscription);
    }
}