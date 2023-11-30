using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Organizarty.Application.Exceptions;

namespace Organizarty.UI.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : ControllerBase
{
    [HttpPost("/Error")]
    public ActionResult OnErrorPost()
    => HandleError();

    [HttpGet("/Error")]
    public ActionResult OnErrorGet()
    => HandleError();

    [HttpPut("/Error")]
    public ActionResult OnErrorPut()
    => HandleError();

    private ActionResult HandleError()
    {

        var acceptHeader = Request.Headers["Content-Type"];

        var error = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;

        if (error is null)
        {
            return Ok("No errors");
        }

        if (acceptHeader == "text/html")
        {
            // TODO: Handle a browser request.
            return Ok("Browser bruh");
        }

        return ApiCall(error);
    }

    private ActionResult ApiCall(Exception error)
    {
        if (error is NotFoundException)
        {
            var ex = (NotFoundException)error;
            return StatusCode(404, new
            {
                Message = ex.Message,
            });
        }

        if (error is ValidationFailException)
        {
            var ex = (ValidationFailException)error;
            return StatusCode(400, new
            {
                Message = ex.Message,
                Erros = ex.Errors.Select(x => x.message)
            });
        }

        if (error is Exception)
        {
            var ex = error;
            return StatusCode(500, ex.ToString());
        }

        return Ok("Everything is okay");
    }
}
