using Microsoft.AspNetCore.Builder;

public static class CustomMiddlewareExtension
{
    public static IApplicationBuilder UseCustomMiddlewareExtension(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomMiddleware>();
    }
}
