using System.Net;
using System.Text.Json;


public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var errorResponse = new
        {
            statusCode = context.Response.StatusCode,
            message = string.Empty,
        };

        switch (exception)
        {
            case KeyNotFoundException _:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                errorResponse = errorResponse with { message = "Resource not found." };
                break;
            case ArgumentException _:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse = errorResponse with { message = "Invalid request data." };
                break;
            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse = errorResponse with { message = "An unexpected error occurred." };
                break;
        }

        var jsonResponse = JsonSerializer.Serialize(errorResponse);
        return context.Response.WriteAsync(jsonResponse);
    }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}

