namespace Synchronizer.Web.Service.Middleware;

public class RequestResponseMiddleware
{
    private readonly RequestDelegate _next;

    public RequestResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpCtx)
    {
        string log = $"[{DateTime.Now:hh:mm:ss tt}]: {httpCtx.Request.Method} {httpCtx.Request.Path}";
        await _next(httpCtx);
        log += $" - Http{httpCtx.Response.StatusCode}";
        Console.WriteLine(log);
    }
}

public static class RequestResponseMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestResponseMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestResponseMiddleware>();
    }
}