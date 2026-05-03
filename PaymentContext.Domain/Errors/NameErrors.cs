using ErrorOr;

namespace PaymentContext.Domain.Errors;

public static class NameErrors
{
    public static Error FirstNameRequired =>
        Error.Validation("Name.FirstName", "First name is required.");

    public static Error LastNameRequired =>
        Error.Validation("Name.LastName", "Last name is required.");

    public static Error TooShort(string field, int min) =>
        Error.Validation($"Name.{field}.TooShort", $"{field} must have at least {min} characters.");

    public static Error TooLong(string field, int max) =>
        Error.Validation($"Name.{field}.TooLong", $"{field} cannot exceed {max} characters.");
}
