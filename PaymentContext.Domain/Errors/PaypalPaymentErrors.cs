using ErrorOr;

namespace PaymentContext.Domain.Errors;

public static class PaypalPaymentErrors
{
    public static Error TransactionCodeRequired =>
        Error.Validation("PayPalPayment.TransactionCodeRequired", "Transaction code is required.");
}
