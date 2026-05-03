using System.Text.RegularExpressions;
using ErrorOr;
using PaymentContext.Common.ValueObjects;
using PaymentContext.Domain.Errors;

namespace PaymentContext.Domain.ValueObjects;

public sealed partial record Email : ValueObject
{
    public string Address { get; }

    private Email(string address)
    {
        Address = address;
    }

    public static ErrorOr<Email> Create(string address)
    {
        if (string.IsNullOrWhiteSpace(address))
        {
            return EmailErrors.Required;
        }

        if (!EmailRegex().IsMatch(address))
        {
            return EmailErrors.Invalid;
        }

        return new Email(address);
    }

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase)]
    private static partial Regex EmailRegex();
}
