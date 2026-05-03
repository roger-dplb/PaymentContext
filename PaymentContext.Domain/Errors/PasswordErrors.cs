namespace PaymentContext.Domain.Errors;

using ErrorOr;

public static class PasswordErrors
{
    public static Error Required =>
        Error.Validation("Password.Required", "Password is required.");

    public static Error TooShort =>
        Error.Validation("Password.TooShort", "Password must have at least 8 characters.");

    public static Error TooLong =>
        Error.Validation("Password.TooLong", "Password cannot exceed 100 characters.");

    public static Error MissingUppercase =>
        Error.Validation("Password.MissingUppercase", "Password must have at least one uppercase letter.");

    public static Error MissingSpecialCharacter =>
        Error.Validation("Password.MissingSpecialCharacter", "Password must have at least one special character.");

    public static Error MissingLowercase =>
        Error.Validation("Password.MissingLowercase", "Password must have at least one lowercase letter.");

    public static Error MissingDigit =>
        Error.Validation("Password.MissingDigit", "Password must have at least one digit.");
}
