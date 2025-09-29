using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(x => x.Title, f => f.Commerce.ProductName())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.Amount, f => f.Finance.Amount(1, 1000))
            .RuleFor(x => x.Date, f => f.Date.Past(1))
            .RuleFor(x => x.PaymentType, f => f.PickRandom<PaymentType>());
    }
}