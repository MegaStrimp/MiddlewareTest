using System.Text;
using Microsoft.AspNetCore.Http;

namespace MiddlewareTest.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logPath;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
            _logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"logs.txt");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var logEntry = new StringBuilder();
            logEntry.AppendLine($"IP - {context.Connection.RemoteIpAddress?.ToString()}");
            logEntry.AppendLine($"Port - {context.Connection.RemotePort}");
            logEntry.AppendLine($"Timestamp - {DateTime.UtcNow}");
            logEntry.AppendLine($"Method - {context.Request.Method}");
            logEntry.AppendLine($"Path - {context.Request.Path}");
            logEntry.AppendLine("----------");
            logEntry.AppendLine();

            await File.AppendAllTextAsync(_logPath,logEntry.ToString());

            await _next(context);
        }
    }
}
