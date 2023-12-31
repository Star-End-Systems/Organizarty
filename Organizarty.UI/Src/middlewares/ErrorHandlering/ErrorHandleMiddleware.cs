using System.Net;
using Newtonsoft.Json;
using Organizarty.Application.Exceptions;

namespace Organizarty.UI.Middlewares.ErrorHandlering;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger _logger;

    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, RequestDelegate next)
    {
        this.next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationFailException e)
        {
            ErroLogger(e);

            context.Response.StatusCode = 400;

            var body = new
            {
                Message = e.Message,
                Errors = e.Errors
            };

            await context.Response.WriteAsJsonAsync(body);
        }
        catch (NotFoundException e)
        {
            ErroLogger(e);

            await context.Response.WriteAsJsonAsync(new
            {
                Message = e.Message
            });
        }
        catch (Exception e)
        {
            ErroLogger(e);
            await context.Response.WriteAsJsonAsync(new
            {
                Message = "Something went wrong, try again later"
            });
        }
    }

    private void ErroLogger(Exception ex)
    {
        _logger.LogError(ex, JsonConvert.SerializeObject(new
        {
            Success = false,
            Message = ex.Message,
            Code = HttpStatusCode.BadRequest,
        }));

        // TODO: Automatically use when on non prod env. 
        // _logger.LogError(ex.StackTrace);
    }
}
