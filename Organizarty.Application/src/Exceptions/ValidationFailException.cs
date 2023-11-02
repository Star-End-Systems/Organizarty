namespace Organizarty.Application.Exceptions;

public class ValidationFailException : Exception
{
    public List<string> ErrorList { get; }

    public ValidationFailException(string msg, List<string> errorList) : base(msg)
    {
        ErrorList = errorList;
    }

    public override string ToString()
    {
        var erros = String.Join("\n", ErrorList);
        return $"{Message}\n-----------\n{erros}";
    }
}
