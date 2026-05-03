using PaymentContext.Domain.Errors;
using ErrorOr;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    public string HolderName { get; private set; }
    public string LastDigits { get; private set; }
    public string PaymentAddress { get; private set; }

    private CreditCardPayment(
        PaymentDetails details,
        string holderName,
        string lastDigits,
        string paymentAddress) : base(details)
    {
        HolderName = holderName;
        LastDigits = lastDigits;
        PaymentAddress = paymentAddress;
    }

    public static ErrorOr<CreditCardPayment> Create(
        PaymentDetails details,
        string holderName,
        string lastDigits,
        string paymentAddress)
    {
        var errors = Validate(details);
        if (string.IsNullOrEmpty(holderName))
        {
            errors.Add(CreditCardPaymentErrors.HolderNameRequired);
        }

        if (string.IsNullOrEmpty(lastDigits))
        {
            errors.Add(CreditCardPaymentErrors.LastDigitsRequired);
        }
        else if (lastDigits.Length != 4)
        {
            errors.Add(CreditCardPaymentErrors.InvalidLastDigits);
        }

        if (string.IsNullOrEmpty(paymentAddress))
        {
            errors.Add(CreditCardPaymentErrors.PaymentAddressRequired);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new CreditCardPayment(details,
            holderName, lastDigits, paymentAddress);
    }
}
