using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine("Request Headers:");
        foreach (var header in context.Request.Headers)
        {
            Console.WriteLine($"{header.Key}: {header.Value}");
        }

        // Call the next delegate/middleware in the pipeline
        await _next(context);
                // Log response headers
        Console.WriteLine("Response Headers:");
        foreach (var header in context.Response.Headers)
        {
            Console.WriteLine($"{header.Key}: {header.Value}");
        }
    }
}
