using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CommandResult : ICommandResult
{
    public CommandResult()
    {

    }
    public CommandResult(bool isValid, string message)
    {
        IsValid = isValid;
        Message = message;
    }

    public bool IsValid { get; set; }
    public string Message { get; set; }
}