using PaymentContext.Common.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email(string email) : ValueObject
{
    public string Address { get; private set; } = email;
}