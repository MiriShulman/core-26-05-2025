namespace OurApi.Middlewares;
public class Our5thMiddleware
{
    private RequestDelegate nextReq;
    public Our5thMiddleware(RequestDelegate request)
    {
        this.nextReq = request;
    }
    public async Task Invoke(HttpContext content)
    {
        int i = 200;
        bool res1 = Helper.IsBetween(i, 1, 100);
        bool res2 = i.IsBetween(1, 100);
        await content.Response.WriteAsync($"Our 5th Middleware res1: {res1}. res2: {res2}\n");
        await nextReq(content);
        await content.Response.WriteAsync($"Our 5th Middlware finish");
    }
}

public static class Our5thMiddlewareHelper
{
    public static void UseOur5th(this IApplicationBuilder application)
    {
        application.UseMiddleware<Our5thMiddleware>();
    }
}

public static class Helper{
    public static bool IsBetween(this int num, int min, int max)
    {
        return num > min
            && num < max;
    }
}