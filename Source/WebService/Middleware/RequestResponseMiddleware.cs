using Synchronizer.Infrastructure.Cache;

namespace Synchronizer.Web.Service.Middleware;

public class RequestResponseMiddleware
{
    private readonly RequestDelegate _next;

    public RequestResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpCtx, IStatusCache status)
    {
        string log = $"[{DateTime.Now:hh:mm:ss tt}]: {httpCtx.Request.Method} /Zoom/Status";
        await _next(httpCtx);
        log += $" {status.ReceivedStatus} - Http{httpCtx.Response.StatusCode}";
        Console.WriteLine(log);
    }
}

public static class RequestResponseMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestResponseMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseWhen(httpCtx => httpCtx.Request.Path == "/Zoom/Status",
            bld => bld.UseMiddleware<RequestResponseMiddleware>());
    }
}