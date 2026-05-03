using PaymentContext.Domain.Errors;
using PaymentContext.Domain.ValueObjects;
using ErrorOr;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment : Payment
{
    public string BarCode { get; private set; }

    public string BoletoNumber { get; private set; }

    private BoletoPayment(
        PaymentDetails details,
        string barCode)
        : base(details)
    {
        BarCode = barCode;
        BoletoNumber =
            Guid.NewGuid().ToString().Replace("-", "")[..10].ToUpperInvariant();
    }

    public static ErrorOr<BoletoPayment> Create(PaymentDetails details, string barCode)
    {
        var errors = Validate(details);
        if (string.IsNullOrEmpty(barCode))
        {
            errors.Add(BoletoPaymentErrors.BarCodeRequired);
        }


        if (errors.Count > 0)
        {
            return errors;
        }


        return new BoletoPayment(
            details, barCode);
    }
}
