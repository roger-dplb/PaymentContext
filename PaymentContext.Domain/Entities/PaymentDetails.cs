using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public sealed record PaymentDetails(
    DateTime PaidDate,
    DateTime ExpireDate,
    decimal Total,
    decimal TotalPaid,
    Document Document,
    string Payer,
    Address Address,
    Email Email);
