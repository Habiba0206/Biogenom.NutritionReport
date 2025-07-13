using Biogenom.NutritionReport.Api.Common;
using Biogenom.NutritionReport.Domain.Common.Exceptions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.NutritionReport.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                Error = "Validation failed",
                Details = ex.Errors.Select(e => e.ErrorMessage).ToList()
            });
        }
        catch (DbUpdateException ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                Error = "Database error",
                Details = new List<string> { ex.InnerException?.Message ?? ex.Message }
            });
        }
        catch (EntityDeletedException ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                Error = "Entity was already deleted",
                Details = new List<string> { ex.InnerException?.Message ?? ex.Message }
            });
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                Error = "There is no such entity",
                Details = new List<string> { ex.InnerException?.Message ?? ex.Message }
            });
        }

        catch (EntityExistsException ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                Error = "This entity exists",
                Details = new List<string> { ex.InnerException?.Message ?? ex.Message }
            });
        }

        //catch (Exception ex)
        //{
        //    _logger.LogError(ex, "Unhandled exception occurred");
        //    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        //    context.Response.ContentType = "application/json";
        //    await context.Response.WriteAsJsonAsync(new ErrorResponse
        //    {
        //        Error = "Something went wrong on the server"
        //    });
        //}
    }
}
