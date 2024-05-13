namespace BlogApi.Logging.Headers
{
    public static class LogHeadersMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogHeaders(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogHeadersMiddleware>();
        }
    }
}
