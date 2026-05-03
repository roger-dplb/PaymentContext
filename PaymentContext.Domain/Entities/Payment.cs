using ErrorOr;
using PaymentContext.Domain.Errors;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public abstract class Payment
{
    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public Document Document { get; private set; }
    public string Payer { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }

    protected Payment(PaymentDetails details)
    {
        Number = Guid.NewGuid().ToString().Replace("-", "")[..10].ToUpperInvariant();
        PaidDate = details.PaidDate;
        ExpireDate = details.ExpireDate;
        Total = details.Total;
        TotalPaid = details.TotalPaid;
        Document = details.Document;
        Payer = details.Payer;
        Address = details.Address;
        Email = details.Email;
    }

    protected static List<Error> Validate(PaymentDetails details)
    {
        List<Error> errors = [];
        if (details.PaidDate > DateTime.Now)
        {
            errors.Add(PaymentErrors.InvalidPaidDate);
        }

        if (details.ExpireDate < DateTime.Now)
        {
            errors.Add(PaymentErrors.InvalidExpiredDate);
        }

        if (details.Total <= 0)
        {
            errors.Add(PaymentErrors.InvalidTotalAmount);
        }

        if (details.TotalPaid <= 0)
        {
            errors.Add(PaymentErrors.InvalidTotalPaidAmount);
        }

        if (string.IsNullOrEmpty(details.Payer))
        {
            errors.Add(PaymentErrors.InvalidPayer);
        }

        if (details.TotalPaid < details.Total)
        {
            errors.Add(PaymentErrors.TotalPaidAmountMinorThanTotalAmount);
        }

        return errors;
    }
}
