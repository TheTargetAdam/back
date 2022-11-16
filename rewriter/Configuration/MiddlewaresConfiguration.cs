using rewriter.api.Middlewares;

namespace rewriter.api.Configuration
{
    public static class MiddlewaresConfiguration
    {
        public static IApplicationBuilder UseAppMiddlewares(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }

}
