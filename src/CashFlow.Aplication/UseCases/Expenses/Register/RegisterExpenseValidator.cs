using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Aplication.UseCases.Expenses.Register;

public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero");
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date must be today or in the past");
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage("Payment type is invalid");
    }
}