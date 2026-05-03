using ErrorOr;
using PaymentContext.Common.ValueObjects;
using PaymentContext.Domain.Errors;

namespace PaymentContext.Domain.ValueObjects;

public sealed record Name : ValueObject
{
    private const int _minLength = 3;
    private const int _maxLength = 40;

    public string FirstName { get; }
    public string LastName { get; }

    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static ErrorOr<Name> Create(string firstName, string lastName)
    {
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(firstName))
        {
            errors.Add(NameErrors.FirstNameRequired);
        }
        else if (firstName.Length < _minLength)
        {
            errors.Add(NameErrors.TooShort(nameof(FirstName), _minLength));
        }
        else if (firstName.Length > _maxLength)
        {
            errors.Add(NameErrors.TooLong(nameof(FirstName), _maxLength));
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            errors.Add(NameErrors.LastNameRequired);
        }
        else if (lastName.Length < _minLength)
        {
            errors.Add(NameErrors.TooShort(nameof(LastName), _minLength));
        }
        else if (lastName.Length > _maxLength)
        {
            errors.Add(NameErrors.TooLong(nameof(LastName), _maxLength));
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Name(firstName, lastName);
    }
}
