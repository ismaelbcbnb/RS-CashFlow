namespace CashFlow.Exception.ExceptionsBase;

public class ErrorOnValidationExeption(List<string> errorMessages) : CashFlowException
{
    public List<string> Errors { get; set; } = errorMessages;
}