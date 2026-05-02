using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name(string firstName, string lastName) : ValueObject
{
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
}