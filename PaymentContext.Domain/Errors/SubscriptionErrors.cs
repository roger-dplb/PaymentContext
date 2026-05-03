namespace PaymentContext.Domain.Errors;

using ErrorOr;

public class SubscriptionErrors
{
    public static Error HasSubscriptionActive =>
        Error.Validation("Subscription.HasActive", "Student already has an active subscription.");
}
