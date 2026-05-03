using ErrorOr;

namespace PaymentContext.Domain.Errors;

public static class BoletoPaymentErrors
{
    public static Error BarCodeRequired =>
        Error.Validation("BoletoPayment.BarcodeRequired", "Bar code is required.");
}
