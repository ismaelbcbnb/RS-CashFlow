using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Aplication.UseCases.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
    {
        Validate(request);
        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        if (titleIsEmpty)
        {
            throw new ArgumentException("Title is required");
        }
        
        if(request.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero");
        }

        if (DateTime.Compare(request.Date, DateTime.Today) > 0)
        {
            throw new ArgumentException("Date must be today or in the past");
        }
        
        if(!Enum.IsDefined(typeof(PaymentType), request.PaymentType))
        {
            throw new ArgumentException("Payment type is invalid");
        }
        
    }
}