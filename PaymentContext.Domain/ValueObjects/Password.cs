using System.Text.RegularExpressions;
using ErrorOr;
using PaymentContext.Common.ValueObjects;
using PaymentContext.Domain.Errors;

namespace PaymentContext.Domain.ValueObjects;

public record Password : ValueObject
{
    public string Value { get; }

    private Password(string value)
    {
        Value = value;
    }

    public static ErrorOr<Password> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return PasswordErrors.Required;
        }

        List<Error> errors = [];

        if (value.Length < 8)
        {
            errors.Add(PasswordErrors.TooShort);
        }

        if (value.Length > 100)
        {
            errors.Add(PasswordErrors.TooLong);
        }

        if (!Regex.IsMatch(value, @"[A-Z]"))
        {
            errors.Add(PasswordErrors.MissingUppercase);
        }

        if (!Regex.IsMatch(value, @"[a-z]"))
        {
            errors.Add(PasswordErrors.MissingLowercase);
        }

        if (!Regex.IsMatch(value, @"[0-9]"))
        {
            errors.Add(PasswordErrors.MissingDigit);
        }

        if (!Regex.IsMatch(value, @"[!@#$%^&*(),.?""':;{}|<>]"))
        {
            errors.Add(PasswordErrors.MissingSpecialCharacter);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Password(value);
    }
}
