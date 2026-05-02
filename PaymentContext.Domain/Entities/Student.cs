namespace PaymentContext.Domain.Entities;

public class Student(
    string firstName,
    string lastName,
    string document,
    string email,
    string address,
    IList<Subscription> subscriptions)
{
    private readonly IList<Subscription> _subscriptions = subscriptions;
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public string Document { get; private set; } = document;
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