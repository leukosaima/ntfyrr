using System.Text;

namespace ntfyrr.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.EnableBuffering();
        context.Request.Body.Position = 0;

        using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
        {
            var requestBody = await reader.ReadToEndAsync();
            Console.WriteLine(requestBody);
        }

        context.Request.Body.Position = 0;

        await _next(context);
    }
}
