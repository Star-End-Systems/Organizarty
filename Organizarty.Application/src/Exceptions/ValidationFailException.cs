namespace Organizarty.Application.Exceptions;

public class ValidationFailException : Exception
{
    public List<string> ErrorList { get; }

    public ValidationFailException(string msg, List<string> errorList) : base(msg)
    {
        ErrorList = errorList;
    }
}
