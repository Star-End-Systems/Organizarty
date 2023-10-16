namespace Organizarty.Application.Exceptions;

public class EmailsenderException : Exception
{
    public EmailsenderException(string msg) : base(msg) { }
}
