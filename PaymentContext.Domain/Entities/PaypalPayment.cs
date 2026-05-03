using ErrorOr;
using PaymentContext.Domain.Errors;
using PaymentContext.Domain.ValueObjects;


namespace PaymentContext.Domain.Entities;

public class PaypalPayment : Payment
{
    public string TransactionCode { get; private set; }

    private PaypalPayment(
        PaymentDetails details,
        string transactionCode) : base(details)
    {
        TransactionCode = transactionCode;
    }

    public static ErrorOr<PaypalPayment> Create(PaymentDetails details, string transactionCode)
    {
        var errors = Validate(details);
        if (string.IsNullOrEmpty(transactionCode))
        {
            errors.Add(PaypalPaymentErrors.TransactionCodeRequired);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new PaypalPayment(
            details, transactionCode);
    }
}
