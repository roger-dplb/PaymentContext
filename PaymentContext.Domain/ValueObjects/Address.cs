using ErrorOr;
using PaymentContext.Common.ValueObjects;
using PaymentContext.Domain.Errors;

namespace PaymentContext.Domain.ValueObjects;

public sealed record Address : ValueObject
{
    public string Street { get; }
    public string Number { get; }
    public string Neighborhood { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }
    public string ZipCode { get; }

    private Address(
        string street,
        string number,
        string neighborhood,
        string city,
        string state,
        string country,
        string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
    }

    public static ErrorOr<Address> Create(
        string street,
        string number,
        string neighborhood,
        string city,
        string state,
        string country,
        string zipCode)
    {
        List<Error> errors = [];

        if (string.IsNullOrWhiteSpace(street))
        {
            errors.Add(AddressErrors.FieldRequired(nameof(Street)));
        }

        if (string.IsNullOrWhiteSpace(number))
        {
            errors.Add(AddressErrors.FieldRequired(nameof(Number)));
        }

        if (string.IsNullOrWhiteSpace(neighborhood))
        {
            errors.Add(AddressErrors.FieldRequired(nameof(Neighborhood)));
        }

        if (string.IsNullOrWhiteSpace(city))
        {
            errors.Add(AddressErrors.FieldRequired(nameof(City)));
        }

        if (string.IsNullOrWhiteSpace(state))
        {
            errors.Add(AddressErrors.FieldRequired(nameof(State)));
        }

        if (string.IsNullOrWhiteSpace(country))
        {
            errors.Add(AddressErrors.FieldRequired(nameof(Country)));
        }

        if (string.IsNullOrWhiteSpace(zipCode))
        {
            errors.Add(AddressErrors.FieldRequired(nameof(ZipCode)));
        }
        else if (zipCode.Count(char.IsDigit) != 8)
        {
            errors.Add(AddressErrors.InvalidZipCode);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Address(street, number, neighborhood, city, state, country, zipCode);
    }
}
