namespace Organizarty.Application.Exceptions;

public class ValidationFailException : Exception
{
 public List<ValidationError> Errors { get; private set; }

    public ValidationFailException(string msg, List<ValidationError> errors) : base(msg)
     => Errors = errors;

    public ValidationFailException(string msg)
      : this(msg, new List<ValidationError>()) { }

    public override string ToString()
    {
        var erros = String.Join("\n", Errors);
        return $"{Message}\n-----------\n{erros}";
    }

    public record ValidationError(string message, string field) { }
}

