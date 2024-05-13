using BlogApi.Logging.Headers;

namespace BlogApi.Logging
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggerMiddleware> _logger;

        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation(
                    "Request {method} {query} {url} \n {headers}",
                    context.Request?.Method,
                    context.Request?.Query,
                    context.Request?.Path.Value,
                    String.Join("\n ", context.Request?.Headers.Select(h => $"{h.Key}: {h.Value}")));

            var originalResponseBodyStream = context.Response.Body;

            var responseBodyStream = new MemoryStream();

            context.Response.Body = responseBodyStream;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            _logger.LogInformation(
                "Request {method} {query} {url} \n " +
                "Response {contentType} {body} => {statusCode} \n {headers}",
                context.Request?.Method,
                context.Request?.Query,
                context.Request?.Path.Value,
                context.Response?.ContentType,
                responseBody,
                context.Response?.StatusCode,
                String.Join("\n ", context.Response?.Headers.Select(h => $"{h.Key}: {h.Value}")));

            await responseBodyStream.CopyToAsync(originalResponseBodyStream);
        }
    }
}
