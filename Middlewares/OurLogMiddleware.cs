using System.Diagnostics;

namespace OurApi.Middlewares;

public class OurLogMiddleware
{
    private RequestDelegate next;
    public OurLogMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task Invoke(HttpContext c)
    {
        await c.Response.WriteAsync($"Our Log Middleware start\n");
        var stopw = new Stopwatch();
        stopw.Start();
        await next(c);
        Console.WriteLine($"{c.Request.Path}.{c.Request.Method} took {stopw.ElapsedMilliseconds}ms.");
        await c.Response.WriteAsync("Our Log Middleware end\n");
    }
}
public static class OurLogMiddlewareHelper
{
    public static void UseOurLog(this IApplicationBuilder application)
    {
        application.UseMiddleware<OurLogMiddleware>();
    }
}