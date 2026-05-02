using PaymentContext.Common.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Address(
    string street,
    string number,
    string neighborhood,
    string city,
    string state,
    string country,
    string zipCode) : ValueObject
{
    public string Street { get; private set; } = street;
    public string Number { get; private set; } = number;
    public string Neighborhood { get; private set; } = neighborhood;
    public string City { get; private set; } = city;
    public string State { get; private set; } = state;
    public string Country { get; private set; } = country;
    public string ZipCode { get; private set; } = zipCode;
}