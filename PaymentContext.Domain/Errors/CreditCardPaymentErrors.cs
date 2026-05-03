using ErrorOr;

namespace PaymentContext.Domain.Errors;

public static class CreditCardPaymentErrors
{
    public static Error HolderNameRequired =>
        Error.Validation("CreditCardPayment.HolderNameRequired", "Holder name is required.");

    public static Error LastDigitsRequired =>
        Error.Validation("CreditCardPayment.LastDigitsRequired", "Last digits is required.");

    public static Error InvalidLastDigits =>
        Error.Validation("CreditCardPayment.InvalidLastDigits", "Last digits must be 4 characters long.");

    public static Error PaymentAddressRequired =>
        Error.Validation("CreditCardPayment.PaymentAddressRequired", "Payment address is required.");
}
