using ErrorOr;

namespace PaymentContext.Domain.Errors;

public static class EmailErrors
{
    public static Error Required =>
        Error.Validation("Email.Required", "Email is required.");

    public static Error Invalid =>
        Error.Validation("Email.Invalid", "Email format is invalid.");
}
