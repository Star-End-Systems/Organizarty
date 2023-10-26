namespace Organizarty.Application.Exceptions;

public class ExpiredDataException : Exception
{
    public ExpiredDataException(string msg) : base(msg) { }
}
