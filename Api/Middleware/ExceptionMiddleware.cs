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

        switch (exception)
        {
            case KeyNotFoundException _:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            case InvalidOperationException _:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case ArgumentException _:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        var errorResponse = new
        {
            statusCode = context.Response.StatusCode,
            message = exception.Message,
        };

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

