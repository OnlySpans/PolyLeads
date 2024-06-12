using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Services.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problemDetails = CreateProblemDetails(exception);

        httpContext.Response.StatusCode = problemDetails.Status!.Value;

        await httpContext
           .Response
           .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private ProblemDetails CreateProblemDetails(Exception e)
    {
        return e switch
        {
            RecognitionException ex                    => BuildResponse(StatusCodes.Status500InternalServerError, ex),
            ResourceNotFoundException ex               => BuildResponse(StatusCodes.Status404NotFound, ex),
            AuthenticationException ex                 => BuildResponse(StatusCodes.Status401Unauthorized, ex),
            AuthorizationException ex                  => BuildResponse(StatusCodes.Status401Unauthorized, ex),
            UnsupportedRecognitionFileTypeException ex => BuildResponse(StatusCodes.Status400BadRequest, ex),
            RoleManagementException ex                 => BuildResponse(StatusCodes.Status400BadRequest, ex),
            UnpermittedResourceException ex            => BuildResponse(StatusCodes.Status400BadRequest, ex),
            ApiException ex                            => BuildResponse(StatusCodes.Status500InternalServerError, ex),
            ValidationException ex => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Detail = string.Join(".\n", ex.Errors)
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Detail = "Unhandled Server Error"
            }
        };
    }

    private ProblemDetails BuildResponse(int statusCode, ApiException ex) =>
        new()
        {
            Status = statusCode,
            Detail = ex.DisplayMessage
        };
}