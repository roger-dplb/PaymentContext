using ErrorOr;

namespace PaymentContext.Domain.Errors;

public static class PaymentErrors
{
    public static Error InvalidPaidDate =>
        Error.Validation("Payment.PaidDate.Invalid", "Paid date must be in the past.");

    public static Error InvalidTotalAmount =>
        Error.Validation("Payment.TotalAmount.Invalid", "Amount must be greater than zero.");

    public static Error InvalidTotalPaidAmount =>
        Error.Validation("Payment.TotalPaidAmount.Invalid", "Paid amount must be greater than zero.");

    public static Error InvalidExpiredDate =>
        Error.Validation("Payment.ExpiredDate.Invalid", "Expired date must be in the future.");

    public static Error InvalidPayer =>
        Error.Validation("Payment.Payer.Invalid", "Payer is required.");

    public static Error TotalPaidAmountMinorThanTotalAmount =>
        Error.Validation("Payment.TotalPaidAmount.MinorThanTotalAmount",
            "Paid amount must be greater than or equal to total amount.");
}
