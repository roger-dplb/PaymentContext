using ErrorOr;

namespace PaymentContext.Domain.Errors;

public static class AddressErrors
{
    public static Error FieldRequired(string field) =>
        Error.Validation($"Address.{field}.Required", $"{field} is required.");

    public static Error InvalidZipCode =>
        Error.Validation("Address.ZipCode.Invalid", "ZipCode format is invalid.");
}
